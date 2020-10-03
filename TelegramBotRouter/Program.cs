using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRouter.Json;
using System.IO;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotRouter
{
    class Program
    {
        static List<ICommand> commands = Commands.commands;
        
        static Result result;
        static Path path = new Path();
        static Addition addition;


        private static readonly TelegramBotClient bot = new TelegramBotClient("1380437409:AAE5n24Rj9qzhSPzLPwYu2ApX");
        static void Main(string[] args)
        {
            DirectorySetting directorySettings = new DirectorySetting();
            directorySettings.FileExists();// проверил существует ли файл
            path.FromFile(directorySettings);//прочитал начальный путь из файла
            Commands.InitializationCommands();//инициализировал комманды



            bot.OnMessage += Bot_OnMessage;//события при приходе сообщений

            var me = bot.GetMeAsync().Result;
            Console.Title = me.FirstName;

            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Message msg = e.Message;
            

            if (msg==null)
            {
                return;
            }



            if (msg.Type==Telegram.Bot.Types.Enums.MessageType.Text)
            {
                //await bot.SendTextMessageAsync(msg.Chat.Id, ApiCreator.ApiToString(ReturnApi(msg.Text)));    
                await bot.SendTextMessageAsync(msg.Chat.Id, ApiCreator.Json(ReturnApi(msg.Text)));
            }



            if(msg.Type== Telegram.Bot.Types.Enums.MessageType.Document)
            {
                var file = await bot.GetFileAsync(msg.Document.FileId);
                FileStream fs = new FileStream(path.path + "\\" + msg.Document.FileName, FileMode.Create);
                await bot.DownloadFileAsync(file.FilePath, fs);
                fs.Close();
                fs.Dispose();
            }

        }

     

        static Api ReturnApi(string Message) 
        {
            
            Command thisCommand;
            Query query_analyzer;
            
            Console.Write(path.path + " -->");
            result = new Result();
            query_analyzer = new Query(Message);// считали команду
            addition = query_analyzer.ThisAddition();
            thisCommand = query_analyzer.ThisCommand();

            foreach (var command in commands)
            {
                if (thisCommand.command == command.CommandName)
                {
                    command.Start(addition, ref path, out result);
                    break;
                }
                else
                {
                    result.MessageAfterCommand = "Неизвестная команда";
                }
            }
            result.Show();
            return new Api(path, result);
        }
    }
}

using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotRouter.Json;
using System.IO;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotRouter.Cd;
using Telegram.Bot.Args;

namespace TelegramBotRouter
{
    class Program
    {
        static List<ICommand> commands = Commands.commands;
        
        static Result result;
        static Path path = new Path();
        static Addition addition;
        static Api api;
        static Message msg;

        private static readonly TelegramBotClient bot = BotSetting.bot;
        static void Main(string[] args)
        {
            DirectorySetting directorySettings = new DirectorySetting();
            directorySettings.FileExists();// проверил существует ли файл
            path.FromFile(directorySettings);//прочитал начальный путь из файла
            Commands.InitializationCommands();//инициализировал комманды



            bot.OnMessage +=  Bot_OnMessage;//события при приходе сообщений
            bot.OnCallbackQuery += Bot_OnCallbackQuery;
            

            var me = bot.GetMeAsync().Result;
            Console.Title = me.FirstName;

            bot.StartReceiving();
            Console.WriteLine("Enter для выхода");
            Console.ReadLine();
            bot.StopReceiving();
        }

        private static void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            if (api.IsDownload)
            {
                SendFile(e);
            }
            else
            {
                NewDirOnCallbackQuery(e);
            }
            
        }

        private static void SendFile(CallbackQueryEventArgs e)
        {
            bot.SendDocumentAsync(msg.Chat.Id, new FileStream(path.path + "\\" + e.CallbackQuery.Data, FileMode.Open));
        }
        private static void NewDirOnCallbackQuery(CallbackQueryEventArgs e)
        {
            

            
                CdCommand cdCommand = new CdCommand();

                for (int i = 0; i < api.Directories.Count; i++)
                {
                    if (e.CallbackQuery.Data == api.Directories[i].directory)
                    {
                        SendTextMess($"cd .{api.Directories[i].directory}");
                    }
                }
            
            
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            msg = e.Message;
            

            if (msg==null)
            {
                return;
            }



            if (msg.Type==Telegram.Bot.Types.Enums.MessageType.Text)
            {              
                SendTextMess(msg.Text);
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
        
        static async private void SendTextMess(string messageText)
        {
            api = ReturnApi(messageText);
            string message = ApiCreator.ApiToString(api);
            InlineKeyboardMarkup keyboard = Keyboard.GetKeyboard(api);

            await bot.SendTextMessageAsync(msg.Chat.Id, message, replyMarkup: keyboard);
        }
     

        static Api ReturnApi(string Message) 
        {
            
            Command thisCommand;
            Query query_analyzer;

            Console.Clear();
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
            return new Api(path, result);
        }
    }
}

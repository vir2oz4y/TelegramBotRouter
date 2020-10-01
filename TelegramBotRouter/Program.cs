
using System;
using System.Collections.Generic;
using TelegramBotRouter.Json;

namespace TelegramBotRouter
{
    class Program
    {    

        static void Main(string[] args)
        {
            List<ICommand> commands = Commands.commands;
            DirectorySetting directorySettings = new DirectorySetting();
            Result result;
            Path path = new Path();
            Query query_analyzer ;// получаем данные из текстбокса
            Addition addition;
            Command thisCommand;


            directorySettings.FileExists();

            path.FromFile(directorySettings);
            Commands.InitializationCommands();

            while (true)
            {
                Console.Write(path.path+" -->");
                result = new Result();
                query_analyzer = new Query(Console.ReadLine());// считали команду
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

                
                Console.WriteLine(ApiCreator.Json(path, result));
            }
        }
    }
}

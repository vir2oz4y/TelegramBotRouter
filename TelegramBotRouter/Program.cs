using System;
using System.Collections.Generic;

namespace TelegramBotRouter
{
    class Program
    {    

        static void Main(string[] args)
        {
            List<ICommand> commands = Commands.commands;
            BotSettings botSettings = new BotSettings();
            Path path = new Path();
            Query query_analyzer ;// получаем данные из текстбокса
            Addition addition;
            Command thisCommand;

            botSettings.FileExists();

            path.FromFile(botSettings);
            Commands.InitializationCommands();

            while (true)
            {
                Console.WriteLine(path.path);
                query_analyzer = new Query(Console.ReadLine());// считали команду
                addition = query_analyzer.ThisAddition();
                thisCommand = query_analyzer.ThisCommand();

                foreach(var command in commands)
                {
                    if (thisCommand.command==command.CommandName())
                    {
                        command.Start(addition,ref path);
                    }
                }

                
            }
        }
    }
}

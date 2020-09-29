using System;
using System.Collections.Generic;
using TelegramBotRouter.Cd;
using TelegramBotRouter.Ls;
using TelegramBotRouter.Mkdir;
using TelegramBotRouter.DDir;

namespace TelegramBotRouter
{
    class Commands
    {
        public static List<ICommand> commands { get; private set; } = new List<ICommand>(); 
        public static void InitializationCommands() {
            commands.Add(new CdCommand());
            commands.Add(new LsCommand());
            commands.Add(new MkDirCommand());
            commands.Add(new DDirCommand());
        }

    }
}

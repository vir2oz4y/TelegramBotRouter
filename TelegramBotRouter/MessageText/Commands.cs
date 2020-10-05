
using System.Collections.Generic;
using TelegramBotRouter.Cd;
using TelegramBotRouter.Ls;
using TelegramBotRouter.Dir;
using TelegramBotRouter.Help;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRouter.MessageText.Download;

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
            commands.Add(new FDDirCommand());
            commands.Add(new HelpCommand());
            commands.Add(new DownloadCommand());
        }

    }
}

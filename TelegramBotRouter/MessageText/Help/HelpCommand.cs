using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotRouter.Help
{
    class HelpCommand : ICommand
    {
        public string CommandDescription => "Show information about commands\n";

        public string CommandName => "help";

        Result result = new Result();
        public void Start(Addition _addition, ref Path _path, out Result _result)
        {

            result.AddHelpArray();

            _result = result;
        }
    }
}

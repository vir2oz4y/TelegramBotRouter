using System.IO;

namespace TelegramBotRouter.Ls
{
    class LsCommand : ICommand
    {
        string ICommand.CommandName => "ls";

        public string CommandDescription => "Show all files and directories in path\n";

        Result result = new Result();
        Path path;
        

        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            path = _path;
            if (_path.IsExists())
            {
                result.AddArrays(AllFile(), AllDirectories());
            }

            result.MessageAfterCommand = "Список файлов и директорий:";
            _result = result;
        }

        private string[] AllDirectories()
        {
            return Directory.GetDirectories(path.path);
        }

        private string[] AllFile()
        {
            return Directory.GetFiles(path.path);
        }
    }
}

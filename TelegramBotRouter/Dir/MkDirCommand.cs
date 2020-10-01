using System.IO;

namespace TelegramBotRouter.Dir
{
    class MkDirCommand : ICommand
    {
        public string CommandName => "mkdir";

        public string CommandDescription => "Create directory\n";

        private Result result = new Result();
        private Addition addition;
        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            addition = _addition;

            if (IsNowDirectory())
            {
                string currentPath = _path.path + "\\" + addition.addition.Substring(1);
                Directory.CreateDirectory(currentPath) ;
                result.MessageAfterCommand = $"Директория создана в {_path.path}";
            }
            else if (IsFullNameDir())
            {
                Directory.CreateDirectory(addition.addition);
                result.MessageAfterCommand = $"Директория создана  {addition.addition}";
            }
            else
            {
                result.MessageAfterCommand = "Директория не создана";
            }
            
            
            _result = result;
        }


        private bool IsFullNameDir()
        {
            return (Directory.Exists(Directory.GetParent(addition.addition).FullName)) ? true : false;
        }

        private bool IsNowDirectory()
        {
            return (addition.addition[0] == '.') ? true : false;
        }

    }
}

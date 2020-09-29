using System.IO;

namespace TelegramBotRouter.Mkdir
{
    class MkDirCommand : ICommand
    {
        public string CommandName => "mkdir";
        private Result result = new Result();
        private Addition addition;
        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            addition = _addition;

            if (IsNowDirectory())
            {
                string currentPath = _path.path + "\\" + addition.addition.Substring(1);
                Directory.CreateDirectory(currentPath) ;
                result.relultAfterCommand = $"Директория создана в {_path.path}";
            }
            else if (IsFullNameDir())
            {
                Directory.CreateDirectory(addition.addition);
                result.relultAfterCommand = $"Директория создана  {addition.addition}";
            }
            else
            {
                result.relultAfterCommand = "Директория не создана";
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

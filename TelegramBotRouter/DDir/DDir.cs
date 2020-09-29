using System.IO;

namespace TelegramBotRouter.DDir
{
    class DDirCommand : ICommand
    {
        public string CommandName => "ddir";

        private Result result = new Result();
        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            try
            {
                Directory.Delete(_path.path + "\\" + _addition.addition);
                result.relultAfterCommand = "Директория удалена";
            }
            catch
            {
                result.relultAfterCommand = "Директория не существует";
            }
            
            _result = result;
        }
    }
}

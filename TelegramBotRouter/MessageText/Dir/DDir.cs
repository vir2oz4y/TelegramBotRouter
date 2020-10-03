using System;
using System.IO;

namespace TelegramBotRouter.Dir
{
    class DDirCommand : ICommand //удаляет пустую папку
    {
        public string CommandName => "ddir";

        public string CommandDescription => "delete directory if it is empty\n";

        private Result result = new Result();
        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            try
            {
                Directory.Delete(_path.path + "\\" + _addition.addition);
                result.MessageAfterCommand = "Директория удалена";
            }
            catch (Exception e)
            {
                result.MessageAfterCommand =e.Message;
            }
            
            _result = result;
        }
    }
}

using System;
using System.IO;

namespace TelegramBotRouter.Dir
{
    class DDirCommand : ICommand //удаляет пустую папку
    {
        public string CommandName => "ddir";

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

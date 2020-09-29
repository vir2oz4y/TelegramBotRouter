using System;
using System.IO;
using System.Threading.Tasks;

namespace TelegramBotRouter.Dir
{
    class FDDirCommand : ICommand
    {
        public string CommandName => "fddir";
        private Result result = new Result();
        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            try
            {
                DeleteFile(_path.path + "\\" + _addition.addition);
                result.MessageAfterCommand = "Директория и все ее файлы удалены";
            }
            catch (Exception e)
            {
                result.MessageAfterCommand = e.Message;
            }

            _result = result;
        }

        private async void DeleteFile(string path)
        {
            await Task.Run(()=> Directory.Delete(path, true));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TelegramBotRouter.MessageText.Download
{
    class DownloadCommand : ICommand
    {
        public string CommandDescription => "Download file";

        public string CommandName => "download";
        private Result result = new Result();

        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            result.AddFileInArray(Directory.GetFiles(_path.path));
            result.MessageAfterCommand = "Файлы для скачивания:";
            result.IsDownload = true;
            _result = result;
        }
    }
}

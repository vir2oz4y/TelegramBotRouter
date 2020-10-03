using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotRouter.Json
{
    class Api
    {
        public Api() { }
        public Api(Path path, Result result)
        {

            this.path = path.path;
            this.messageAfterCommand = result.MessageAfterCommand;
            this.messageResult = new List<MessageResult>();
            for (int i = 0; i < result.resultCommandLs.Count; i++)
            {
                messageResult.Add(new MessageResult { message = result.resultCommandLs[i] });
            }
        }

        public string path { get; set; }
        public string messageAfterCommand { get; set; }
        public List<MessageResult> messageResult { get; set; }
        
    }
}

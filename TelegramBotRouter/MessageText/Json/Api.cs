using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotRouter.MessageText.Json;

namespace TelegramBotRouter.Json
{
    class Api
    {
        public Api() { }
        public Api(Path path, Result result)
        {

            this.Path = path.path;
            this.MessageAfterCommand = result.MessageAfterCommand;
            this.Files = new List<Files>();
            this.Directories = new List<Directories>();
            this.Helps = new List<Helps>();
            this.IsDownload = result.IsDownload;

            AddAll(result);
            
        }

        private void AddAll(Result result)
        {
            AddFile(result);
            AddDir(result);
            AddHelp(result);
        }
        private void AddFile(Result result)
        {
            for (int i = 0; i < result.files.Count; i++)
            {
                Files.Add(new Files { file = result.files[i] });
            }
        }

        private void AddDir(Result result)
        {
            for (int i = 0; i < result.directories.Count; i++)
            {
                Directories.Add(new Directories { directory = result.directories[i] });
            }
        }

        private void AddHelp(Result result)
        {
            for (int i = 0; i < result.infoHelp.Count; i++)
            {
                Helps.Add(new Helps { help = result.infoHelp[i] });
            }
        }


        public string Path { get; set; }
        public string MessageAfterCommand { get; set; }
        public bool IsDownload { get; set; }
        public List<Files> Files  { get; set; }
        public List<Directories> Directories { get; set; }
        public List<Helps> Helps { get; set; }
        
    }
}

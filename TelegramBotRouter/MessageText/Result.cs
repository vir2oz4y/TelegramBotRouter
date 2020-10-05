using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotRouter
{
    class Result
    {
        public bool IsDownload { get; set; } = false;
        public string MessageAfterCommand { get; set; } = null;
        public List<string> directories { get; set; } = new List<string>();
        public List<string> files { get; set; } = new List<string>();
        public List<string> infoHelp { get; set; } = new List<string>();


        public void AddArrays(string[] file, string[] directories)
        {
            Clear();
            AddDirectoriesInArray(directories);
            AddFileInArray(file);
        }

        private void Clear()
        {
            directories.Clear();
            files.Clear();
            infoHelp.Clear();
        }

        public void AddHelpArray()
        {
            Clear();
            for (int i = 0; i < Commands.commands.Count; i++)
            {
                infoHelp.Add (Commands.commands[i].CommandName+" - "+ Commands.commands[i].CommandDescription);
            }
        }

        public void AddFileInArray(string[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                files.Add(DeletePath(file[i]));
            }
        }

        private void AddDirectoriesInArray(string[] _directories)
        {
            for (int i = 0; i < _directories.Length; i++)
            {
                directories.Add(DeletePath(_directories[i]));
            }
        }

        private string DeletePath(string fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf('\\'));
        }
    }
}

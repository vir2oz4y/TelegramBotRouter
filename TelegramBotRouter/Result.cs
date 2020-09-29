using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotRouter
{
    class Result
    {
        public string relultAfterCommand { get; set; } = null;
        List<string> resultCommandLs { get; set; } = new List<string>();

        public void AddAllInResultCommandLs(string[] file, string[] directories)
        {
            AddDirectoriesInArray(directories);
            AddFileInArray(file);
        }

        private void Clear()
        {
            resultCommandLs.Clear();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(relultAfterCommand);

            if (resultCommandLs.Count==0)
            {
                Console.WriteLine("Директория пуста");
            }
            else
            {
                ShowResultCommandLs();
            }
            
            Clear();
        }

        private void AddFileInArray(string[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                resultCommandLs.Add(file[i]);
            }
        }

        private void AddDirectoriesInArray(string[] directories)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                resultCommandLs.Add(directories[i]);
            }
        }


        private void ShowResultCommandLs()
        {
            for (int i = 0; i < resultCommandLs.Count; i++)
            {
                Console.WriteLine(resultCommandLs[i]);
            }
        }
    }
}

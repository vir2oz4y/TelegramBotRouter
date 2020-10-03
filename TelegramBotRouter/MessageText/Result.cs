﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotRouter
{
    class Result
    {
        public string MessageAfterCommand { get; set; } = null;
        public List<string> resultCommandLs { get; set; } = new List<string>();


        public void AddAllInResultCommandLs(string[] file, string[] directories)
        {
            Clear();
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
            Console.WriteLine(MessageAfterCommand);

            if (resultCommandLs.Count==0 && MessageAfterCommand== "Список файлов и директорий:")
            {
                Console.WriteLine("Директория пуста");
            }
            else
            {
                ShowResultCommandLs();
            }
            
            
        }

        public void ShowHelp()
        {
            Clear();
            for (int i = 0; i < Commands.commands.Count; i++)
            {
                resultCommandLs.Add (Commands.commands[i].CommandName+" - "+ Commands.commands[i].CommandDescription);
            }
        }

        private void AddFileInArray(string[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                resultCommandLs.Add(DeletePath(file[i]));
            }
        }

        private void AddDirectoriesInArray(string[] directories)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                resultCommandLs.Add(DeletePath(directories[i]));
            }
        }

        private string DeletePath(string fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf('\\'));
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

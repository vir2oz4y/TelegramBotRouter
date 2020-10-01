﻿using System.IO;

namespace TelegramBotRouter.Cd
{
    class CdCommand : ICommand
    {
        private Addition addition;
        private Path path;
        private Result result= new Result();
        CdParent cdParent = new CdParent();
        CdChild cdNext = new CdChild();
        CdNew cdNew = new CdNew();


        string ICommand.CommandName => "cd";

        public string CommandDescription => "Moves from the specified directory to the specified one\n" +
            "1. cd .directoryName - moves to child directoty with name directoryName\n" +
            "2. cd c:\\path - moves to path\n" +
            "3. cd - moves to Parent directory\n";

        public void Start(Addition _addition, ref Path _path, out Result _result)
        {
            addition = _addition;
            addition.CheckAddition();
            path = _path;   

            if (IsNewDirectory())
            {
                path = cdNew.NewDirectory(path, addition);
            }

            if (IsPreviousDirectory())
            {
                path = cdParent.PreviousDirectory(path);
            }

            if (IsNextDirectory())
            {
                path = cdNext.NextDirectory(path, addition);
            }

            result.MessageAfterCommand = "Переход выполнен!";
            _result = result;
            _path = path;
        }



        private bool IsNewDirectory()
        {
            if (addition.addition is null)
            {
                return false;
            }

            return Directory.Exists(addition.addition) ? true : false;
        }

        private bool IsPreviousDirectory()
        {
            if (addition.addition is null)
            {
                return false;
            }
            return addition.addition == "-" ? true : false;
        }

        private bool IsNextDirectory()
        {
            if (addition.addition is null)
            {
                return false;
            }
            return addition.addition[0] == '.' ? true : false;
        }


    }
}

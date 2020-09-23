using System.IO;

namespace TelegramBotRouter.Cd
{
    class CdCommand : ICommand
    {
        private Addition addition;
        private Path path;
        CdPrevious cdPrevious = new CdPrevious();
        CdNext cdNext = new CdNext();
        CdNew cdNew = new CdNew();

        private string commandName = "cd";

        public string CommandName()
        {
            return commandName;
        }


        public void Start(Addition _addition, ref Path _path)
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
                path = cdPrevious.PreviousDirectory(path);
            }

            if (IsNextDirectory())
            {
                path = cdNext.NextDirectory(path, addition);
            }



            _path = path;
        }



        private bool IsNewDirectory()
        {
            if (addition.addition is null)
            {
                return false;
            }

            return Directory.Exists(path.path + "\\" + addition.addition) ? true : false;
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

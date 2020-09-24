using System.IO;

namespace TelegramBotRouter.Cd
{
    class CdCommand : ICommand
    {
        private Addition addition;
        private Path path;
        private Result result= new Result();
        CdPrevious cdPrevious = new CdPrevious();
        CdNext cdNext = new CdNext();
        CdNew cdNew = new CdNew();


        string ICommand.CommandName => "cd";


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
                path = cdPrevious.PreviousDirectory(path);
            }

            if (IsNextDirectory())
            {
                path = cdNext.NextDirectory(path, addition);
            }

            result.relultAfterCommand = "Переход выполнен!";
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

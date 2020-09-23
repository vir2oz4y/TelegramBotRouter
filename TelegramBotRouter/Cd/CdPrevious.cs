

namespace TelegramBotRouter.Cd
{
    class CdPrevious
    {
        Path path;

        public Path PreviousDirectory(Path LastPath)
        {
            path = LastPath;

            if (IsFirstDir())// если это начальная дерриктория возвращаем путь который был
            {
                return path;
            }
            else//иначе изменяем путь на новый и возвращаем его
            {
                ReplicatePath();
                return path;
            }
        }

        private bool IsFirstDir()
        {
            return path.path.Length == 3 ? true : false;
        }

        private void ReplicatePath()// изменяем путь на предыдущую дирректорию 
        {
            path.path = path.path.Remove(path.path.LastIndexOf('\\')+1);           
        }
    }
}

using System.IO;

namespace TelegramBotRouter.Cd
{
    class CdChild
    {
        Path path;
        Addition addition;
        public Path NextDirectory(Path LastPath, Addition _addition) //следующая дирриктория из текущей
        {
            path = LastPath;
            addition = _addition;

            Path newPath = new Path();

            if (IsExistsDir(CreateNextPath())) //если новая дирриктория существует то меняем текущую на новую
            {
                newPath.path = CreateNextPath();
                return newPath;
            }
            else
            {
                newPath = LastPath;
                return newPath;
            }
        }

        private string CreateNextPath()
        {
            return path.path  +"\\"+ addition.addition.Substring(1, addition.addition.Length - 1);//создали путь следующей дирриктории
        }

        private bool IsExistsDir(string path)// проверка существования новой директории
        {
            return Directory.Exists(path) ? true : false;
        }
    }
}

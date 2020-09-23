using System.IO;

namespace TelegramBotRouter.Cd
{
    class CdNext
    {
        Path path;
        Addition addition;
        public Path NextDirectory(Path LastPath, Addition _addition) //следующая дерриктория из текущей
        {
            path = LastPath;
            addition = _addition;

            Path newPath = new Path();

            if (IsExistsDir(CreateNextPath())) //если новая дерриктория существует то меняем текущую на новую
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
            return path.path  + addition.addition.Substring(1, addition.addition.Length - 1);//создали путь следующей дерриктории
        }

        private bool IsExistsDir(string path)
        {
            return Directory.Exists(path) ? true : false;
        }
    }
}

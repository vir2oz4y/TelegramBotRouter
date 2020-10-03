using System.IO;
namespace TelegramBotRouter.Cd
{
    class CdNew
    {
        public Path NewDirectory(Path path, Addition addition)
        {
            if (Directory.Exists(addition.addition))
            {
                path.path = addition.addition;
            }
            return path;
        }
    }
}

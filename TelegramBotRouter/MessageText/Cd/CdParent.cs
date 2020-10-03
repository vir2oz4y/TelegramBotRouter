using System.IO;

namespace TelegramBotRouter.Cd
{
    class CdParent
    {
        Path path;

        public Path PreviousDirectory(Path LastPath)
        {
            path = LastPath;
            try
            {
                path.path = Directory.GetParent(path.path).FullName;
                return path;
            }
            catch 
            {
                return path;
            }
            
           
        }

    }
}

using System.IO;

namespace TelegramBotRouter
{
    class Path
    {
        public Path() { path = null; }
        public Path(string path_)
        {
            path = path_;
        }

        public string path { get; set; }

        public bool IsExists()
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        public void FromFile(DirectorySetting settings)
        {
            path = File.ReadAllText(settings.filePath);// читает путь из файла
        }

    }
}

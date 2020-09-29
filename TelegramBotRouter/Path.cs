using System.IO;

namespace TelegramBotRouter
{
    class Path
    {
        public Path() { path = null; }
        public Path(string path_)
        {
            path = path_;
            exist = IsExists();
        }

        public string path { get; set; }

        public bool exist { get; }

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

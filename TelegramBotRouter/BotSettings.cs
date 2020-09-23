using System;
using System.IO;

namespace TelegramBotRouter
{
    class BotSettings
    {
        private string fileName="Init";
        public bool IsEmpty { get; set; } = false;
        public string filePath { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;

        public void ChangeFilePath(string NewFilePath)
        {
            File.WriteAllText(filePath, NewFilePath);
        }

        private void CreateFile()
        {
            string newFilePath;
            Console.WriteLine("Введите начальную деррикторию: ");
            newFilePath = Console.ReadLine();
            if (Directory.Exists(newFilePath))
            {
                File.WriteAllText(filePath, newFilePath);
            }
            else
            {
                Console.WriteLine("Неверная дерриктория\nПоробуйте снова");
                CreateFile();
            }
        }

        public void FileExists()
        {
            filePath = filePath + "\\" + fileName;
            if (!File.Exists(filePath))
            {
                CreateFile();
            }     
        }
    }
}

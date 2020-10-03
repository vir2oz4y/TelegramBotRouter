

namespace TelegramBotRouter
{
    class Command
    {
        public string command { get; set; } = null;
        public void ChangeCommand(string query)
        {
            command = query.Split(' ')[0];
            command=command.ToLower();
        }
    }
}

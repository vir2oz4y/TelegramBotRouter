namespace TelegramBotRouter
{
    interface ICommand
    {
        string CommandName();
        void Start(Addition _addition, ref Path _path);
    }
}

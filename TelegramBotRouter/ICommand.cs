namespace TelegramBotRouter
{
    interface ICommand
    {
        string CommandName { get;}
        void Start(Addition _addition, ref Path _path, out Result _result);
    }
}

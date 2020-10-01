namespace TelegramBotRouter
{
    interface ICommand
    {
        string CommandDescription { get; }
        string CommandName { get;}
        void Start(Addition _addition, ref Path _path, out Result _result);
    }
}

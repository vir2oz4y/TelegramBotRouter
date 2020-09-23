namespace TelegramBotRouter
{
    class Query
    {
        private Command command = new Command();
        private Addition addition = new Addition();
        private string query;
        public Query(string query_)
        {

            query = query_;
            Query_analizer();
        }

        private void Query_analizer()
        {
            command.ChangeCommand(query);
            addition.ChangeAddition(query);
        }

        public Command ThisCommand()
        {
            return command;
        }

        public Addition ThisAddition()
        {
            return addition;
        }
    }
}

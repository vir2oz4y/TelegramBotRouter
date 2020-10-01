using Newtonsoft.Json;

namespace TelegramBotRouter.Json
{
    static class ApiCreator
    {
        public static string Json(Path path, Result result)
        {
            Api api = new Api(path, result);
            string json = JsonConvert.SerializeObject(api, Formatting.Indented);
            return json;
        }
    }
}

using Newtonsoft.Json;

namespace TelegramBotRouter.Json
{
    static class ApiCreator
    {

        public static string Json(Api _api)
        {
            string json = JsonConvert.SerializeObject(_api, Formatting.Indented);
            return json;
        }

        public static string ApiToString(Api api)
        {
            string message = "--> " + api.Path + "\n" + api.MessageAfterCommand + "\n";

            if (api.Files.Count == 0)
            {
                return message;
            }

            else
            {
                for (int i = 0; i < api.Files.Count; i++)
                {
                    message += api.Files[i].file + "\n";
                }
                return message;
            }
        }

        //public static string JsonToString(string json)
        //{
        //    Api api = JsonConvert.DeserializeObject<Api>(json);
        //    string message = "--> " + api.Path + "\n" + api.MessageAfterCommand + "\n";

        //    if (api.messageResult.Count==0)
        //    {
        //        return message;
        //    }

        //    else
        //    {
        //        for (int i = 0; i <api.messageResult.Count; i++)
        //        {
        //            message += api.messageResult[i].message + "\n";
        //        }
        //        return message;
        //    }

        //}
    }
}

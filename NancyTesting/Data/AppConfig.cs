using System.IO;
using Newtonsoft.Json;

namespace TrelloTelegramAlarm
{
    internal static class AppConfig
    {
        private static readonly string path = "../../configuration.json";

        private static readonly AppConfigurationJson config =
            JsonConvert.DeserializeObject<AppConfigurationJson>(File.ReadAllText(path));

        public static string TelegramToken => config.TelegramToken;
        public static string TelegramBotName => config.TelegramBotName;
        public static string TrelloApiKey => config.TrelloApiKey;
        public static string PublicURL => config.PublicURL;
        public static string LocalHost => config.LocalHost;
    }

    internal class AppConfigurationJson
    {
        public string TelegramToken { get; set; }
        public string TelegramBotName { get; set; }
        public string TrelloApiKey { get; set; }
        public string PublicURL { get; set; }
        public string LocalHost { get; set; }
    }
}
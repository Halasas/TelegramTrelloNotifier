using System.IO;
using Newtonsoft.Json;

namespace TgBot
{
    public class Configuration
    {
        public Configuration(){}

        public Configuration(string configPath)
            : this(JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configPath))) { }

        public Configuration(Configuration origin)
        {
            this.HostPort = origin.HostPort;
            this.HostUrl = origin.HostUrl;
            this.LocalHost = origin.LocalHost;
            this.TelegramBotName = origin.TelegramBotName;
            this.TelegramBotUrl = origin.TelegramBotUrl;
            this.TelegramToken = origin.TelegramToken;
            this.TrelloApiKey = origin.TrelloApiKey;
            this.TrelloMySecretToken = origin.TrelloMySecretToken;
        }
        public string HostUrl { get; set; }
        public string LocalHost { get; set; }
        public string HostPort { get; set; }

        public string TelegramToken { get; set; }
        public string TelegramBotName { get; set; }
        public string TelegramBotUrl { get; set; }

        public string TrelloApiKey{ get; set; }
        public string TrelloMySecretToken{ get; set; }
    }
}
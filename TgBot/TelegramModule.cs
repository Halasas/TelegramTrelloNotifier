using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Nancy;
using Nancy.ModelBinding;
using Telegram.Bot;
using Telegram.Bot.Types;
using  Newtonsoft.Json;
namespace TgBot
{
    public class TelegramModule : NancyModule
    {
        private static TelegramBotClient client = new TelegramBotClient(
            new Configuration("../../BotConfiguration.json").TelegramToken);
        public TelegramModule()
        {
            Post("/telegram", _ =>
            {
                using (StreamReader streamReader = new StreamReader(Request.Body))
                {
                    Update update = JsonConvert.DeserializeObject<Update>(streamReader.ReadToEnd());
                    client.SendTextMessageAsync(update.Message.Chat.Id, "I'm working!!!!").Wait();
                    client.StartReceiving();
                    client.StopReceiving();
                }
                return HttpStatusCode.OK;
            });
            Get("/telegram", _ => "Suck");
        }

    }
}

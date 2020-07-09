using System.IO;
using System.Net.Http;
using Nancy;
using Newtonsoft.Json.Linq;
using TrelloTelegramAlarm.Trello;

namespace TrelloTelegramAlarm
{
    public class TrelloModule : NancyModule
    {
        public TrelloModule()
        {
            Get("/trello/{ChatID}/", parameters => HttpStatusCode.OK);

            Post("/trello/{ChatID}/", parameters =>
            {
                var chatId = long.Parse(parameters["ChatID"]);
                if (!File.Exists(chatId + ".json")) return HttpStatusCode.Gone;
                var content = new StreamContent(Request.Body).ReadAsStringAsync().Result;
                var Update = JObject.Parse(content);
                ProcessPost(Update, chatId);
                return HttpStatusCode.OK;
            });
        }

        private async void ProcessPost(JObject Update, long ChatId)
        {
            var actionType = Update["action"]?["type"]?.ToString();
            var memberID = Update["action"]?["data"]?["member"]?["id"]?.ToString();
            var boardID = Update["action"]?["data"]?["board"]?["id"]?.ToString();
            var notificationMessage = ActionHandlers.Get(actionType).GetMessage(Update);
            var notification = new Notification(actionType, boardID, memberID, ChatId, notificationMessage);

            await TelegramController.SendNotification(notification);
        }
    }
}
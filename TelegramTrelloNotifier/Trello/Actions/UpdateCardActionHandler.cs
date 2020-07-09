using System;
using System.Text;
using Newtonsoft.Json.Linq;
using TrelloTelegramAlarm.Trello.Actions;

namespace NancyTesting.Trello.Actions
{
    public class UpdateCardActionHandler : IActionHandler
    {
        public string ActionType => "updateCard";

        public string GetMessage(JObject Update)
        {
            if (Update == null) throw new NullReferenceException("Update is null");
            var notificationBuilder = new StringBuilder();
            var boardName = Update["action"]?["data"]?["board"]?["name"];
            var cardName = Update["action"]?["data"]?["card"]?["name"];
            var url = Update["model"]?["url"];
            notificationBuilder.Append("New action in trello board\n" +
                                       $"***{boardName ?? "No Board"}***\n" +
                                       $"This card was updated ***{cardName ?? "No Card"}***\n" +
                                       $"{url}");
            return notificationBuilder.ToString();
        }
    }
}
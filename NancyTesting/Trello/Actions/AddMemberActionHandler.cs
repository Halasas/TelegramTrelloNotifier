using System;
using System.Text;
using Newtonsoft.Json.Linq;
using TrelloTelegramAlarm.Trello.Actions;

namespace NancyTesting.Trello.Actions
{
    public class AddMemberActionHandler : IActionHandler
    {
        public string ActionType => "addMemberToCard";

        public string GetMessage(JObject Update)
        {
            if (Update == null) throw new NullReferenceException("Update is null");
            var notificationBuilder = new StringBuilder();
            var boardName = Update["action"]?["data"]?["board"]?["name"];
            var cardName = Update["action"]?["data"]?["card"]?["name"];
            var memberName = Update["action"]?["data"]?["member"]?["name"];
            var url = Update["model"]?["url"];
            notificationBuilder.Append("New action in trello board\n" +
                                       $"***{boardName ?? "No Board"}***\n" +
                                       $"Member ***{memberName}*** added to the card ***{cardName ?? "No Card"}***\n" +
                                       $"{url}");
            return notificationBuilder.ToString();
        }
    }
}
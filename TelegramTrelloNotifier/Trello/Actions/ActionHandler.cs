using System;
using System.Text;
using Newtonsoft.Json.Linq;

namespace TrelloTelegramAlarm.Trello.Actions
{
    public class ActionHandler : IActionHandler
    {
        public string ActionType => "default";

        public string GetMessage(JObject Update)
        {
            if (Update == null) throw new NullReferenceException("Update is null");
            var notificationBuilder = new StringBuilder();
            var actionType = Update["action"]?["type"];
            var boardName = Update["action"]?["data"]?["board"]?["name"];
            var cardName = Update["action"]?["data"]?["card"]?["name"];
            var memberName = Update["action"]?["data"]?["member"]?["name"];
            notificationBuilder.Append("New action in trello board\n" +
                                       $"***{boardName ?? "No Board"}***\n\n" +
                                       $"{actionType} {cardName ?? "No Card"} : {memberName ?? "No Member"}");
            return notificationBuilder.ToString();
        }
    }
}
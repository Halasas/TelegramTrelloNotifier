using Newtonsoft.Json.Linq;

namespace TrelloTelegramAlarm.Trello.Actions
{
    public interface IActionHandler
    {
        string ActionType { get; }
        string GetMessage(JObject Update);
    }
}
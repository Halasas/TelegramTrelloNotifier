using System.Collections.Generic;

namespace TrelloTelegramAlarm.Trello
{
    public interface INotificationMode
    {
        int Id { get; }
        List<string> AllowedActionTypes { get; }
        bool OnlyThisMember { get; }
        bool OnlySelectedActions { get; }
    }
}
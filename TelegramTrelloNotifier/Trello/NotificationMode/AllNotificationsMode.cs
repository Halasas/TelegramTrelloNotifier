using System.Collections.Generic;

namespace TrelloTelegramAlarm.Trello
{
    public class AllNotificationsMode : INotificationMode
    {
        public int Id => 2;
        public List<string> AllowedActionTypes { get; } = new List<string>();
        public bool OnlyThisMember => false;
        public bool OnlySelectedActions => false;
    }
}
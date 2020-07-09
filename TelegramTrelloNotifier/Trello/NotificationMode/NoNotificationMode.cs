using System.Collections.Generic;

namespace TrelloTelegramAlarm.Trello
{
    public class NoNotificationMode : INotificationMode
    {
        public int Id => 0;
        public List<string> AllowedActionTypes { get; } = new List<string>();
        public bool OnlyThisMember => false;
        public bool OnlySelectedActions => true;
    }
}
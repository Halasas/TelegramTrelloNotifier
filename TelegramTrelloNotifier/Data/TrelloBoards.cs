namespace TrelloTelegramAlarm.Trello
{
    public class TrelloBoard
    {
        public TrelloBoard()
        {
            NotificationMode = 1;
        }

        public string Name { get; set; }
        public string id { get; set; }
        public int NotificationMode { get; set; }
    }
}
namespace TrelloTelegramAlarm.Trello
{
    public class Notification
    {
        public string ActionType;
        public string BoardId;
        public string MemberId;
        public string Message;
        public UserData UserData;

        public Notification(string actionType, string boardId, string memberId, long chatID, string message)
        {
            ActionType = actionType;
            UserData = new UserData(chatID);
            MemberId = memberId;
            Message = message;
            BoardId = boardId;
        }
    }
}
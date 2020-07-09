using System.Linq;

namespace TrelloTelegramAlarm.Trello
{
    public static class NotificationFilter
    {
        public static bool IsAllowed(Notification notification)
        {
            var modeID = notification.UserData
                .Boards.First(q => q.id == notification.BoardId)
                .NotificationMode;
            var mode = NotificationModes.Get(modeID);
            return (!mode.OnlySelectedActions || mode.AllowedActionTypes.Contains(notification.ActionType))
                   && (!mode.OnlyThisMember || notification.MemberId == notification.UserData.TrelloUserId);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace TrelloTelegramAlarm.Trello
{
    public class NotificationModes
    {
        private static readonly List<INotificationMode> all =
            Reflection.GetInstances<INotificationMode>(Reflection.GetAllTypesImplemented<INotificationMode>());

        public static INotificationMode Get(int id)
        {
            var mode = all.FirstOrDefault(q => q.Id == id);
            var defaultMode = new OnlyMyNotifications();
            return mode ?? defaultMode;
        }
    }
}
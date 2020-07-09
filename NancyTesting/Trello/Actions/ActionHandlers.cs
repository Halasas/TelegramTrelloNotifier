using System.Collections.Generic;
using System.Linq;
using TrelloTelegramAlarm.Trello.Actions;

namespace TrelloTelegramAlarm.Trello
{
    public static class ActionHandlers
    {
        private static readonly List<IActionHandler> all =
            Reflection.GetInstances<IActionHandler>(Reflection.GetAllTypesImplemented<IActionHandler>());

        public static IActionHandler Get(string ActionType)
        {
            var action = all.FirstOrDefault(q => q.ActionType == ActionType);
            var defaultAction = new ActionHandler();
            return action ?? defaultAction;
        }
    }
}
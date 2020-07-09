using System.Collections.Generic;

namespace TrelloTelegramAlarm.Trello
{
    public class OnlyMyNotifications : INotificationMode
    {
        public int Id => 1;

        public List<string> AllowedActionTypes
        {
            get
            {
                var actions = new List<string>();
                actions.Add("addMemberToBoard");
                actions.Add("addMemberToCard");
                actions.Add("addMemberToOrganization");
                actions.Add("memberJoinedTrello");
                actions.Add("removeMemberFromBoard");
                actions.Add("removeMemberFromCard");
                actions.Add("removeMemberFromOrganization");
                actions.Add("updateMember");
                return actions;
            }
        }

        public bool OnlyThisMember => true;
        public bool OnlySelectedActions => true;
    }
}
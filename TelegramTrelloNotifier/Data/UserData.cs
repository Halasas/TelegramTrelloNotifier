using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TrelloTelegramAlarm.Trello;

namespace TrelloTelegramAlarm
{
    public class UserData
    {
        public UserData()
        {
        }

        public UserData(long chatID)
        {
            var data = JsonConvert.DeserializeObject<UserData>(File.ReadAllText($"{chatID}.json"));
            ChatID = data.ChatID;
            TgUserName = data.TgUserName;
            TrelloUserId = data.TrelloUserId;
            TrelloUserName = data.TrelloUserName;
            SecretToken = data.SecretToken;
            Boards = data.Boards;
        }

        public long ChatID { get; set; }
        public string TgUserName { get; set; }
        public string TrelloUserId { get; set; }
        public string TrelloUserName { get; set; }
        public string SecretToken { get; set; }
        public TrelloBoard[] Boards { get; set; }

        public void Save()
        {
            File.WriteAllText($"{ChatID}.json", JsonConvert.SerializeObject(this));
        }

        public async void UpdateAsync()
        {
            var trelloController = new TrelloController(this);
            var boards = await trelloController.GetAllBoards();
            foreach (var board in boards)
            {
                if (Boards == null)
                    break;
                var userBoard = Boards.FirstOrDefault(q => q.id == board.id);
                if (userBoard != null)
                    board.NotificationMode = userBoard.NotificationMode;
            }

            Boards = boards;
            var trello = new TrelloController(this);
            foreach (var board in boards) trello.Webhook(board);
            Save();
        }
    }
}
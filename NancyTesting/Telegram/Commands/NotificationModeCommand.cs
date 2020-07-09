using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TrelloTelegramAlarm.Trello;

namespace TrelloTelegramAlarm
{
    public class NotificationModeCommand : ITelegramCommand
    {
        public string CommandRegex => "^/ntf .*";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            var command = update.Message.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var user = update.Message.Chat;
            var userData = new UserData(user.Id);
            var trelloController = new TrelloController(userData);
            userData.UpdateAsync();
            var boards = userData.Boards;
            int mode, id;

            if (!int.TryParse(command[1], out id) || !(boards.Length > id))
            {
                TelegramController.SendText(userData.ChatID, "You write invalid id");
                return $"{update.Message.Text} invalid id";
            }

            if (!int.TryParse(command[2], out mode) || !(mode >= 0 && mode <= 2))
            {
                TelegramController.SendText(userData.ChatID, "You write invalid mode");
                return $"{update.Message.Text} invalid mode";
            }

            boards[id].NotificationMode = mode;
            userData.Save();
            await client.SendTextMessageAsync(update.Message.Chat.Id,
                $"Notification mode for {boards[id].Name} changed to {mode}");
            return $"{update.Message.Text}";
        }
    }
}
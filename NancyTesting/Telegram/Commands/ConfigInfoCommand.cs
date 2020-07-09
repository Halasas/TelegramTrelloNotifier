using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TrelloTelegramAlarm.Trello;

namespace TrelloTelegramAlarm
{
    public class ConfigInfoCommand : ITelegramCommand
    {
        public string CommandRegex => "^/config";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            var user = update.Message.Chat;
            var userData = new UserData(user.Id);
            var trelloController = new TrelloController(userData);
            var text = "This is all your boards:\n" +
                       "id - Name - Mode\n";
            userData.UpdateAsync();
            var boards = userData.Boards;
            for (var i = 0; i < boards.Length; i++) text += $"{i} - {boards[i].Name} - {boards[i].NotificationMode}\n";
            var result = text;
            text += "\n============================" +
                    "\nYou can set 3 different mode for notifier" +
                    "\n0 - No notification from this board" +
                    "\n1 - Only notification about me(default)" +
                    "\n2 - All notification" +
                    "\n\n" +
                    "Write */ntf {ID} {Mode}* to change mode";
            await TelegramController.SendText(userData.ChatID, text, ParseMode.Markdown);
            return $"/config\n+{result}";
        }
    }
}
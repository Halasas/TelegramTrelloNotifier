using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TrelloTelegramAlarm
{
    public class InfoCommand : ITelegramCommand
    {
        public string CommandRegex => "^/help";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            var information = "/reg - Start linking telegram and trello\n" +
                              "/token - If you know a token, use this\n" +
                              "/config - Set or change settings of notifier\n" +
                              "/disable - Use it if you want to disable notifier";
            client.SendTextMessageAsync(update.Message.Chat.Id, information).Wait();
            return "/help \n" + information;
        }
    }
}
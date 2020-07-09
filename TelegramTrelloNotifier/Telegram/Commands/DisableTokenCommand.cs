using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace TrelloTelegramAlarm
{
    public class DisableTokenCommand : ITelegramCommand
    {
        public string CommandRegex => "^/disable";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            File.Delete($"{update.Message.Chat.Id}.json");
            await client.SendTextMessageAsync(update.Message.Chat.Id, "I will not bother you anymore... :c");
            return $"/disable {update.Message.Chat.Id}.json";
        }
    }
}
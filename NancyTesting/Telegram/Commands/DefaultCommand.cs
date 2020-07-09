using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TrelloTelegramAlarm
{
    public class DefaultCommand : ITelegramCommand
    {
        public string CommandRegex => "default";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Ummm... I do not understand human language");
            await client.SendStickerAsync(update.Message.Chat.Id,
                "CAACAgIAAxkBAANuXwOWa9Wwz78Rs7lU0dbUGenfeogAAlcBAAIQGm0ipSs8VPt6NKoaBA");
            await client.SendTextMessageAsync(update.Message.Chat.Id, "It will help you");
            await new InfoCommand().Execute(update, client);
            return "default command was executed";
        }
    }
}
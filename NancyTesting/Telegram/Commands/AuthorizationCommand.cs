using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TrelloTelegramAlarm
{
    public class AuthorizationCommand : ITelegramCommand
    {
        public string CommandRegex => "^/reg";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Follow the link below and accept request");
            await client.SendTextMessageAsync(update.Message.Chat.Id, "https://trello.com/1/authorize" +
                                                                      "?expiration=30days" +
                                                                      "&name=TrelloTelegramBot" +
                                                                      "&scope=read" +
                                                                      "&response_type=token" +
                                                                      "&key=" + $"{AppConfig.TrelloApiKey}");
            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "Then write \n/token {token}\nwith token from link");
            return "New user received the authorization link";
        }
    }
}
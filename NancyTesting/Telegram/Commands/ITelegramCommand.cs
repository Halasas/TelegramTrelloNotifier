using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TrelloTelegramAlarm
{
    public interface ITelegramCommand
    {
        string CommandRegex { get; }
        Task<string> Execute(Update update, TelegramBotClient client);
    }
}
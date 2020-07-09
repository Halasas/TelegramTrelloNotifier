using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TrelloTelegramAlarm.Trello;

namespace TrelloTelegramAlarm
{
    public static class TelegramController
    {
        public static TelegramBotClient TelegramBotClient => new TelegramBotClient(AppConfig.TelegramToken);

        public static void SetWebhook()
        {
            TelegramBotClient.SetWebhookAsync(AppConfig.PublicURL + "/tg").Wait();
        }

        public static void SendText(long chatID, string text)
        {
            TelegramBotClient.SendTextMessageAsync(chatID, text).Wait();
        }

        public static async Task SendText(long chatID, string text, ParseMode parseMode)
        {
            await TelegramBotClient.SendTextMessageAsync(chatID, text, parseMode);
        }

        public static void SendSticker(long chatID, string StickerID)
        {
            TelegramBotClient.SendStickerAsync(chatID, StickerID).Wait();
        }

        public static async Task SendNotification(Notification notification)
        {
            if (NotificationFilter.IsAllowed(notification))
                await SendText(notification.UserData.ChatID, notification.Message, ParseMode.Markdown);
        }
    }
}
using System;
using System.IO;
using Nancy;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TrelloTelegramAlarm
{
    public class TelegramModule : NancyModule
    {
        public TelegramModule()
        {
            Post("/tg", _ =>
            {
                using (var streamReader = new StreamReader(Request.Body))
                {
                    var update = JsonConvert.DeserializeObject<Update>(streamReader.ReadToEnd());
                    if (update.Message == null) return HttpStatusCode.OK;
                    if (update.Message.Type == MessageType.Text && update.Message.Text != null)
                    {
                        var text = update.Message.Text;
                        var command = TelegramCommands.Get(text);
                        Console.WriteLine(command.Execute(update, TelegramController.TelegramBotClient).Result);
                    }
                    else if (update.Message.Type == MessageType.Sticker)
                    {
                        TelegramController.TelegramBotClient.SendStickerAsync(update.Message.Chat.Id,
                            update.Message.Sticker.FileId);
                        Console.WriteLine($"StickerID= {update.Message.Sticker.FileId}");
                    }
                }

                return HttpStatusCode.Accepted;
            });
        }
    }
}
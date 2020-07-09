using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using TrelloTelegramAlarm.Trello;

namespace TrelloTelegramAlarm
{
    public class TokenCommand : ITelegramCommand
    {
        public string CommandRegex => "^/token .*";

        public async Task<string> Execute(Update update, TelegramBotClient client)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var text = update.Message.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (text.Length == 2 && text[1] != null && text[1].Length > 10)
            {
                var http = new HttpClient();
                var response = http.GetAsync("https://api.trello.com/1/members/me/?" +
                                             "fields=fullname,username" +
                                             $"&key={AppConfig.TrelloApiKey}" +
                                             $"&token={text[1]}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    await client.SendTextMessageAsync(update.Message.Chat.Id, "I think... hmm... it`s invalid token");
                    return "Invalid user token";
                }

                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TrelloResponce>(jsonResult);

                var userData = new UserData();
                userData.TrelloUserId = result.id;
                userData.TrelloUserName = result.username;
                userData.ChatID = update.Message.Chat.Id;
                userData.TgUserName = update.Message.Chat.Username;
                userData.SecretToken = text[1];
                var trelloController = new TrelloController(userData);
                userData.Boards = await trelloController.GetAllBoards();
                userData.Save();
            }
            else
            {
                client.SendTextMessageAsync(update.Message.Chat.Id, "I think...hmm... it`s invalid token").Wait();
                return "Invalid user token";
            }

            Console.ForegroundColor = ConsoleColor.White;
            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "Linking between trello and telegram created... \nNow let's config notifier");
            await new ConfigInfoCommand().Execute(update, client);
            return "User token received";
        }

        private class TrelloResponce
        {
            public string id { get; set; }
            public string username { get; set; }
        }
    }
}
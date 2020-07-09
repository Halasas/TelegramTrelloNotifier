using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrelloTelegramAlarm.Trello
{
    public class TrelloController
    {
        public TrelloController(UserData user)
        {
            UserData = user;
        }

        private UserData UserData { get; }

        public async void Webhook(TrelloBoard board)
        {
            var httpClient = new HttpClient();
            var uri = new Uri(
                $"https://api.trello.com/1/tokens/{UserData.SecretToken}/webhooks/?key={AppConfig.TrelloApiKey}");
            var values = new Dictionary<string, string>
            {
                {"description", $"webhook for {UserData.ChatID}"},
                {"callbackURL", $"{AppConfig.PublicURL}/trello/{UserData.ChatID}"},
                {"idModel", board.id}
            };

            var content = new FormUrlEncodedContent(values);
            var response = await httpClient.PostAsync(uri, content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var message = response.Content.ReadAsStringAsync().Result;
                if (message != "A webhook with that callback, model, and token already exists")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public async Task<TrelloBoard[]> GetAllBoards()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("https://api.trello.com/1/members/me/boards?" +
                                                         "fields=name" +
                                                         $"&key={AppConfig.TrelloApiKey}" +
                                                         $"&token={UserData.SecretToken}");
            var boards = JsonConvert.DeserializeObject<TrelloBoard[]>(result);
            foreach (var board in boards) Console.WriteLine($"{board.Name} {board.id}");
            return boards;
        }
    }
}
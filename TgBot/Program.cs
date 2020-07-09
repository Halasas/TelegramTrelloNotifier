using System;
using Nancy;
using Nancy.Hosting.Self;
using Telegram.Bot;

namespace TgBot
{
    class Program
    {
        static void Main(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() {CreateAutomatically = true}
            };
            Configuration config = new Configuration("../../BotConfiguration.json");

            //using (var host = new NancyHost(new Uri(config.LocalHost), new DefaultNancyBootstrapper(), hostConfigs))
            using (var host = new NancyHost(new Uri("http://localhost:80"), new DefaultNancyBootstrapper(), hostConfigs))
            {
                host.Start();
                Console.WriteLine("NancyFX Stand alone test application.");
                Console.WriteLine("Press enter to exit the application");
            }

            TelegramBotClient client = new TelegramBotClient("1267454068:AAEeNwusDtk3CWTS6UaSq-I9tGmzffYXo9s");
            //TelegramBotClient client = new TelegramBotClient(config.TelegramToken);
            client.SetWebhookAsync("https://3c63be14915c.ngrok.io/telegram");
            //config.HostUrl.ToString() + 

            Console.WriteLine("Webhook URL: " + config.HostUrl.ToString() + "/");
            Console.ReadLine();
        }
    }
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Post("/", parameters => HttpStatusCode.Accepted);
            Get("/", parameters => "AAAAAAAAAaaAAAAAaaaAAaAaAAa");
        }
    }
}

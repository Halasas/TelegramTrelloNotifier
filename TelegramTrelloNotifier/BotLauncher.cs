using System;
using Nancy;
using Nancy.Hosting.Self;

namespace TrelloTelegramAlarm
{
    public static class BotLauncher
    {
        private static void Main(string[] args)
        {
            var hostConfigs = new HostConfiguration
            {
                UrlReservations = new UrlReservations {CreateAutomatically = true}
            };
            using (var host = new NancyHost(new Uri(AppConfig.LocalHost), new DefaultNancyBootstrapper(), hostConfigs))
            {
                host.Start();
                Console.WriteLine("NancyFX host - OK");

                TelegramController.SetWebhook();
                Console.WriteLine("Telegram webhook - OK");

                while (true)
                {
                }
            }
        }
    }
}
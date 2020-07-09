using System;
using Nancy;
using Nancy.Hosting.Self;

namespace NancyTestin
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:80")))
            {
                host.Start();

                Console.WriteLine("NancyFX Stand alone test application.");
                Console.WriteLine("Press enter to exit the application");
                Console.ReadLine();
            }
        }
    }

    public class HellowModule : NancyModule
    {
        public HellowModule()
        {
            Get("/", _ => "Hello");
        }
    }
}

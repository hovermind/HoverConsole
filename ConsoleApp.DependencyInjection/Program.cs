using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<EntryPoint>().Run(args);
        }
    }
}

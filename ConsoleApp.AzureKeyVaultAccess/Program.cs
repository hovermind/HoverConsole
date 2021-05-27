using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp.AzureKeyVaultAccess
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<EntryPoint>().Run(args);
        }
    }
}

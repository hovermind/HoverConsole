using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using static ConsoleApp.AzureKeyVaultAccess.Constants.KeyVault;

namespace ConsoleApp.AzureKeyVaultAccess
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            //serviceCollection.AddScoped<IFoo, Foo>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var builtConfig = builder.Build();
            var secretClient = new SecretClient(new Uri($"https://{builtConfig[KeyVaultNameKey]}.vault.azure.net/"), new DefaultAzureCredential());
            builder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());

            var configuration = builder.Build();
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddTransient<EntryPoint>();

            return serviceCollection;
        }
    }
}

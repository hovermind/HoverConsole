using System;
using ConsoleApp.Simple.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Simple
{
	public static class Startup
	{
		public static IServiceCollection ConfigureServices()
		{
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddScoped<IFoo, Foo>();

			serviceCollection.AddTransient<EntryPoint>();

			return serviceCollection;
		}
	}
}

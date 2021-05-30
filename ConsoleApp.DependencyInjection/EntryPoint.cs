using ConsoleApp.Simple.Services;
using System;
using static System.Diagnostics.Debug;

namespace ConsoleApp.Simple
{
    public class EntryPoint
    {
		private IFoo _foo;
		public EntryPoint(IFoo foo)
		{
			_foo = foo;
		}

		public void Run(String[] args)
		{

			WriteLine("\n\n\n\n\n");
			WriteLine("=====================================================================================\n\n");

			WriteLine("DI in console app is working...\n");

			var randomNumber = _foo.GetRandomNumber();
			WriteLine($"Foo.GetRandomNumber(): {randomNumber}");

			WriteLine("\n\n=================================================================================");
			WriteLine("\n\n\n\n\n");

			Console.Read();
		}
	}
}

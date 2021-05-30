using System;

namespace ConsoleApp.Simple.Services
{
    public class Foo : IFoo
    {
        public int GetRandomNumber(int start, int end)
        {
            return new Random().Next(start, end);
        }
    }
}

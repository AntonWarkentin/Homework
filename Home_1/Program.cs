using System;

namespace Home_1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write down your name!");
            var yourName = Console.ReadLine();
            Console.WriteLine("Hello {0}!", yourName);
        }
    }
}
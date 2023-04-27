using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_9
{
    internal class AgeException : ArgumentException
    {
        int Age { get; }

        public AgeException(string message, int age) : base(message)
        {
            Age = age;
            Console.WriteLine($"\n\nYou're setting the Age of {Age}");
        }
    }
}

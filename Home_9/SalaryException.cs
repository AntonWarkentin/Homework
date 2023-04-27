using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_9
{
    internal class SalaryException : ArgumentException
    {
        public int Salary { get; }
        
        public SalaryException(string message, int salary) : base(message)
        {
            Salary = salary;
            Console.WriteLine($"\n\nYou're setting the Salary of {Salary}");
        }
    }
}

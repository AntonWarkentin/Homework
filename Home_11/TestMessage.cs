using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_11
{
    public static class TestMessage
    {
        public static void CalculatorPositiveCase(double operand1, double operand2, double expected, Operation operation)
        {
            if (operand2 < 0)
            {
                Console.WriteLine($"{operand1:f2} {(char)operation} ({operand2:f2}) = {expected:f2}");
            }
            else Console.WriteLine($"{operand1:f2} {(char)operation} {operand2:f2} = {expected:f2}");
        }

        public static void CalculatorNegativeCase(double operand1, double operand2, double notExpected, Operation operation)
        {
            if (operand2 < 0)
            {
                Console.WriteLine($"{operand1:f2} {(char)operation} ({operand2:f2}) != {notExpected:f2}");
            }
            else Console.WriteLine($"{operand1:f2} {(char)operation} {operand2:f2} != {notExpected:f2}");
        }
    }
}

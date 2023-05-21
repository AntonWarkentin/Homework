using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_11.UnitTest
{
    internal class UnitTest_Multiplication
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting Multiplication Unit test!");
        }

        [Test]
        public void PositiveTests([Values(3, 1, 0)] double operand1, [Values(-1.9, 1.9, 80)] double operand2)
        {
            TestNotification.NotifyPositive(operand1, operand2, operand1 * operand2, Operation.Multiplication);

            Assert.AreEqual(
                Calculator.Multiplication(operand1, operand2),
                operand1 * operand2);
        }

        [Test, Sequential, MaxTime(10)]
        public void NegativeTests([Range(-0.4, 0.4, 0.2)] double operand1, [Range(-3, 1, 2)] double operand2)
        {
            TestNotification.NotifyNegative(operand1, operand2, operand1 + operand2, Operation.Multiplication);

            Assert.That(Calculator.Multiplication(operand1, operand2), Is.Not.EqualTo(operand1 + operand2));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Finishing Multiplication Unit test!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_11.UnitTest
{
    internal class UnitTest_Division
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting Division Unit test!");
        }

        [Test, Order(1), Pairwise, Category("Positive Test")]
        public void PositiveTests([Random(1, 3, 3)] double operand1, [Values(-1.9, 1.9, 80)] double operand2)
        {
            TestNotification.NotifyPositive(operand1, operand2, operand1 / operand2, Operation.Division);

            Assert.That(
                operand1 / operand2,
                Is.EqualTo(Calculator.Division(operand1, operand2)));
        }

        [Test, Order(2), Sequential]
        [Category("Negative Test")]
        public void NegativeTests([Values(-0.4, 0.4, 0.2)] double operand1, [Range(-3, 1, 2)] double operand2)
        {
            TestNotification.NotifyNegative(operand1, operand2, operand1 - operand2, Operation.Division);

            Assert.That(
                Calculator.Multiplication(operand1, operand2), 
                Is.Not.EqualTo(operand1 - operand2));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Finishing Division Unit test!");
        }
    }
}

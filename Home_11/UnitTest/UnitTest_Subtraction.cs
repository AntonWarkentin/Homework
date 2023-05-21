using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Home_11.UnitTest
{
    internal class UnitTest_Subtraction
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting Subtraction Unit test!");
        }

        [Test, Pairwise, Category("Positive Test")]
        public void PositiveTests([Random(-0.9, 0.9, 4)] double operand1, [Random(-1, 1, 5)] double operand2)
        {
            TestNotification.NotifyPositive(operand1, operand2, operand1 - operand2, Operation.Subtraction);

            Assert.AreEqual(
                Calculator.Subtraction(operand1, operand2), 
                operand1 - operand2);
        }

        [Test]
        [Retry(5)]
        [Category("Negative Test")]
        public void NegativeTests()
        {
            Random random = new Random();
            var operand1 = random.NextDouble() * random.Next(-100, 100);
            var operand2 = random.NextDouble() * random.Next(-100, 100);
            var notExpected = random.NextDouble() * random.Next(-100, 100);
            var expected = Calculator.Subtraction(operand1, operand2);

            TestNotification.NotifyNegative(operand1, operand2, notExpected, Operation.Subtraction);
            Assert.That(notExpected, Is.Not.EqualTo(expected));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Finishing Subtraction Unit test!");
        }
    }
}

using NUnit.Framework;
using System.ComponentModel;

namespace Home_11.UnitTest
{
    [TestFixture]
    public class UnitTest_Sum
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting Sum Unit test!");
        }

        [TestCase(20, 15, ExpectedResult = 35)]
        [TestCase(20, -15, ExpectedResult = 5)]
        [TestCase(0.21, 2, ExpectedResult = 2.21)]
        [TestCase(-0.21, 2.21, ExpectedResult = 2)]
        [TestCase(-0, 0, ExpectedResult = 0)]
        [NUnit.Framework.Description("Different positive test cases")]
        public double PositiveTests(double operand1, double operand2)
        {
            double result = Calculator.Sum(operand1, operand2);
            TestNotification.NotifyPositive(operand1, operand2, result, Operation.Sum);
            return result;
        }

        [TestCase(20, 15, 34)]
        [TestCase(20, -15, 35)]
        [TestCase(0.21, 2, 2)]
        [TestCase(-0.21, 2.3, 2)]
        [TestCase(0, -0, -0.1)]
        [TestCase(1, -1, 0, Ignore = "Ignore this")]
        public void NegativeTests(double operand1, double operand2, double notExpected)
        {
            TestNotification.NotifyNegative(operand1, operand2, notExpected, Operation.Sum);

            Assert.That(
                Calculator.Sum(operand1, operand2),
                Is.Not.EqualTo(notExpected));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Finishing Sum Unit test!");
        }
    }
}
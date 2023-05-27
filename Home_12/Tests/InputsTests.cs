using OpenQA.Selenium;
using System.Globalization;

namespace Home_12.Tests
{
    public class InputsTests : BaseTest
    {
        [Test]
        public void InputsTest()
        {
            NavigationHelper.NavigateAndAssertPage("Inputs", chrome);
            var inputField = chrome.FindElement(By.TagName("input"));
            List<string> testData = new List<string>() { "123", "r53", "6uty", "92", "aa", "7.6", "3,2", "1000000", "" };

            foreach (var testDataItem in testData)
            {
                inputField.SendKeys(testDataItem);
                string initialInputValue = inputField.GetAttribute("value");
                Assert.That(initialInputValue == InputFieldFormat(testDataItem));

                if (initialInputValue == "") initialInputValue = "0";

                inputField.SendKeys(Keys.ArrowUp);
                inputField.SendKeys(Keys.ArrowDown);
                inputField.SendKeys(Keys.ArrowDown);

                string changedInputValue = inputField.GetAttribute("value");
                int expectedValue = (int)double.Parse(initialInputValue, CultureInfo.InvariantCulture) - 1;
                Assert.That(int.Parse(changedInputValue), Is.EqualTo(expectedValue));

                inputField.Clear();
            }
        }

        private static string InputFieldFormat(string stringToFormat)
        {
            return string.Concat(stringToFormat.Where(x => char.IsDigit(x) || x == '.' || x == ',').Select(x => x == ',' ? '.' : x));
        }
    }
}
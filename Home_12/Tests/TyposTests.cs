using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Home_12.Tests
{
    public class TyposTests : BaseTest
    {
        [Test]
        public void TyposTest()
        {
            NavigationHelper.NavigateAndAssertPage("Typos", chrome);

            var expectedText = "Sometimes you'll see a typo, other times you won't.";
            var textElements = chrome.FindElements(By.TagName("p"));
            var textToCheck = textElements[1].Text;

            Assert.That(textToCheck, Is.EqualTo(expectedText));
        }
    }
}
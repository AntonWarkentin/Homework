using OpenQA.Selenium;

namespace Home_12.Tests
{
    public class AddRemoveElementsTests : BaseTest
    {
        [Test]
        public void AddRemoveElementsTest()
        {
            NavigationHelper.NavigateAndAssertPage("Add/Remove Elements", chrome);

            var addButton = chrome.FindElement(By.XPath("//button[text()='Add Element']"));
            addButton.Click();
            addButton.Click();

            var deleteButtons = chrome.FindElements(By.XPath("//button[text()='Delete']"));
            Assert.That(deleteButtons.Count, Is.EqualTo(2));

            deleteButtons[0].Click();
            deleteButtons = chrome.FindElements(By.XPath("//button[text()='Delete']"));
            Assert.That(deleteButtons.Count, Is.EqualTo(1));
        }
    }
}
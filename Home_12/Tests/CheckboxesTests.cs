using OpenQA.Selenium;

namespace Home_12.Tests
{
    public class CheckboxesTests : BaseTest
    {
        [Test]
        public void CheckboxesTest()
        {
            NavigationHelper.NavigateAndAssertPage("Checkboxes", chrome);

            var checkBoxes = chrome.FindElements(By.CssSelector("[type = checkbox]"));
            var firstCheckBox = checkBoxes.First();
            var secondCheckBox = checkBoxes.Last();

            Assert.That(firstCheckBox.GetAttribute("checked"), Is.EqualTo(null));
            firstCheckBox.Click();
            Assert.That(firstCheckBox.GetAttribute("checked"), Is.EqualTo("true"));

            Assert.That(secondCheckBox.GetAttribute("checked"), Is.EqualTo("true"));
            secondCheckBox.Click();
            Assert.That(secondCheckBox.GetAttribute("checked"), Is.EqualTo(null));
        }
    }
}
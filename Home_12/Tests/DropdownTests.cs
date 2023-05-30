using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Home_12.Tests
{
    public class DropdownTests : BaseTest
    {
        [Test]
        public void DropdownTest()
        {
            NavigationHelper.NavigateAndAssertPage("Dropdown", chrome);

            SelectElement selectDropdown = new(chrome.FindElement(By.Id("dropdown")));
            Assert.That(selectDropdown.Options, Is.Not.Null);

            foreach (var element in selectDropdown.Options)
            {
                if (element.Enabled)
                {
                    selectDropdown.SelectByText(element.Text);
                    Assert.That(selectDropdown.SelectedOption.Text, Is.EqualTo(element.Text));
                }
            }
        }
    }
}
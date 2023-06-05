using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Home_14.Pages
{
    public class DynamicControlsPage : BasePage
    {
        private By CheckBox = By.Id("checkbox");
        private By CheckBoxButton = By.XPath("//form[@id='checkbox-example']//button");
        private By CheckBoxMessage = By.XPath("//form[@id='checkbox-example']//p[@id='message']");
        private By TextInput = By.XPath("//form[@id='input-example']//input");
        private By TextButton = By.XPath("//form[@id='input-example']//button");
        private By InputMessage = By.XPath("//form[@id='input-example']//p[@id='message']");
        private By Loading = By.Id("loading");

        public void ClickCheckBoxButton()
        {
            driver.FindElement(CheckBoxButton).Click();
            WaitForIt();
        }

        public void AssertCheckboxVisibility(bool expectedVisibility)
        {
            var foundCheckBox = driver.FindElements(CheckBox);
            bool visibility;

            if (foundCheckBox.Count == 0)
            {
                visibility = false;
            }
            else visibility = true;

            Assert.That(visibility, Is.EqualTo(expectedVisibility));
        }

        public void AssertCheckBoxMessage(string expectedMessage)
        {
            Assert.That(driver.FindElement(CheckBoxMessage).Text, Is.EqualTo(expectedMessage));
        }

        public void ClickTextButton()
        {
            driver.FindElement(TextButton).Click();
            WaitForIt();
        }

        public void AssertInputIsDisabled(bool expectedDisabled)
        {
            var disabledString = driver.FindElement(TextInput).GetAttribute("disabled");
            bool disabled;

            if (disabledString == null)
            {
                disabled = false;
            }
            else
            {
                disabled = bool.Parse(disabledString);
            }
             
            Assert.That(disabled, Is.EqualTo(expectedDisabled));
        }

        public void AssertInputMessage(string expectedMessage)
        {
            Assert.That(driver.FindElement(InputMessage).Text, Is.EqualTo(expectedMessage));
        }

        public void WaitForIt()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => !driver.FindElement(Loading).Displayed);
        }
    }
}
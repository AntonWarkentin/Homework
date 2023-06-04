using OpenQA.Selenium;
using Core;

namespace Home_13
{
    internal class CheckoutStep1Page : BasePage
    {
        private string url = "https://www.saucedemo.com/checkout-step-one.html";

        private By FirstNameInput = By.Id("first-name");
        private By LastNameInput = By.Id("last-name");
        private By PostalCodeInput = By.Name("postalCode");
        private By ContinueButton = By.XPath("//input[@type='submit']");

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public BasePage FillInputAndSubmit()
        {
            driver.FindElement(FirstNameInput).SendKeys("TestFirstNameInput");
            driver.FindElement(LastNameInput).SendKeys("TestLastNameInput");
            driver.FindElement(PostalCodeInput).SendKeys("TestPostalCodeInput");
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(ContinueButton));
        }
    }
}

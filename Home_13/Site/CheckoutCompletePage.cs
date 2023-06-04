using OpenQA.Selenium;
using Core;

namespace Home_13
{
    internal class CheckoutCompletePage : BasePage
    {
        private string url = "https://www.saucedemo.com/checkout-complete.html";

        private By CompleteText = By.XPath("//div[@class='complete-text']");
        private By BackToProductsButton = By.XPath("//button[@id='back-to-products']");
        private string expectedMessage = "Your order has been dispatched, and will arrive just as fast as the pony can get there!";

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public void AssertFinishMessage()
        {
            Assert.That(driver.FindElement(CompleteText).Text, Is.EqualTo(expectedMessage));
        }

        public BasePage BackToProducts()
        {
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(BackToProductsButton));
        }
    }
}

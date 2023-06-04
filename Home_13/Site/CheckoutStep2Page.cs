using OpenQA.Selenium;
using System.Globalization;
using Core;

namespace Home_13.Site
{
    internal class CheckoutStep2Page : BasePage
    {
        private const string url = "https://www.saucedemo.com/checkout-step-two.html";

        private By ItemTotalPrice = By.ClassName("summary_subtotal_label");
        private By FinishButton = By.Id("finish");

        public void ComparePrice(double expectedPrice)
        {
            var priceText = driver.FindElement(ItemTotalPrice).Text;
            var itemTotalPrice = double.Parse(priceText.Substring(priceText.Length - 5), CultureInfo.InvariantCulture);
            Assert.That(itemTotalPrice, Is.EqualTo(expectedPrice));
        }

        public BasePage FinishPurchase()
        {
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(FinishButton));
        }
    }
}

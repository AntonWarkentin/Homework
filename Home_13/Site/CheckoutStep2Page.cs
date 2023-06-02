using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_13
{
    internal class CheckoutStep2Page : BasePage
    {
        private const string url = "https://www.saucedemo.com/checkout-step-two.html";

        private By ItemTotalPrice = By.XPath("//div[@class='summary_subtotal_label']");
        private By FinishButton = By.XPath("//button[@id='finish']");

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

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

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_13
{
    internal class CartPage : BasePage
    {
        private const string url = "https://www.saucedemo.com/cart.html";

        private By CheckoutButton = By.XPath("//*[@id='checkout']");
        private By ContinueShoppingButton = By.XPath("//*[@id='continue-shopping']");
        private By CartItems = By.ClassName("cart_item");
        private By InventoryItemPrice = By.ClassName("inventory_item_price");


        public CartPage()
        {
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public BasePage GoToCheckout()
        {
            var checkOut = driver.FindElement(CheckoutButton);
            return Browser.Instance.OpenNewPageByClick(checkOut);
        }

        public BasePage ContinueShopping()
        {
            var checkOut = driver.FindElement(ContinueShoppingButton);
            return Browser.Instance.OpenNewPageByClick(checkOut);
        }

        public void AssertCartCostIsEqualToSelectedItems(double selectedItemsCost)
        {
            var cartItems = driver.FindElements(CartItems);
            double cartItemsCost = 0;

            foreach (var cartItem in cartItems)
            {
                cartItemsCost += double.Parse(cartItem.FindElement(InventoryItemPrice).Text.Trim('$'), CultureInfo.InvariantCulture);
            }

            Assert.That(cartItemsCost, Is.EqualTo(selectedItemsCost));
        }
    }
}

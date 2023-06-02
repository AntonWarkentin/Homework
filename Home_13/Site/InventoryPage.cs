﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Home_13
{
    internal class InventoryPage : BasePage
    {
        private string url = "https://www.saucedemo.com/inventory.html";

        private By Items = By.XPath("//*[@class='inventory_item']");
        private By ShoppingCartLink = By.XPath("//*[@class='shopping_cart_link']");
        private By PriceOfItem = By.ClassName("inventory_item_price");
        private By SideBarMenuButton = By.Id("react-burger-menu-btn");
        private By LogOutButton = By.Id("logout_sidebar_link");
        private By AddRemoveItemButton = By.TagName("button");

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public double AddToCartAndGetPrice(int itemNum)
        {
            var itemToAdd = driver.FindElements(Items)[itemNum];

            if (itemToAdd.FindElement(AddRemoveItemButton).Text == "Add to cart")
            {
                itemToAdd.FindElement(AddRemoveItemButton).Click();
            }

            return double.Parse(itemToAdd.FindElement(PriceOfItem).Text.Trim('$'), CultureInfo.InvariantCulture);
        }
        
        public double DeleteFromCart(int itemNum)
        {
            var itemToDelete = driver.FindElements(Items)[itemNum];

            if (itemToDelete.FindElement(AddRemoveItemButton).Text == "Remove")
            {
                itemToDelete.FindElement(AddRemoveItemButton).Click();
            }

            return 0;
        }

        public IWebElement GetShoppingCartLink()
        {
            return driver.FindElement(ShoppingCartLink);
        }

        public int AmountOfItemsInCart()
        {
            return (GetShoppingCartLink().Text == "")? 0: int.Parse(GetShoppingCartLink().Text);
        }

        public BasePage GoToCart()
        {
            var cartLink = GetShoppingCartLink();
            return Browser.Instance.OpenNewPageByClick(cartLink);
        }

        public void OpenSideBarMenu()
        {
            driver.FindElement(SideBarMenuButton).Click();
        }

        public BasePage LogOut()
        {
            OpenSideBarMenu();
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(LogOutButton));
        }
    }
}

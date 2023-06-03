using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_13
{
    internal static class NavigationHelper
    {
        private static Dictionary<string, Func<BasePage>> pages1 = new Dictionary<string, Func<BasePage>>()
        {
            { "https://www.saucedemo.com/", () => new LoginPage() },
            { "https://www.saucedemo.com/inventory.html", () => new InventoryPage() },
            { "https://www.saucedemo.com/cart.html", () => new CartPage() },
            { "https://www.saucedemo.com/checkout-step-one.html", () => new CheckoutStep1Page() },
            { "https://www.saucedemo.com/checkout-step-two.html", () => new CheckoutStep2Page() },
            { "https://www.saucedemo.com/checkout-complete.html", () => new CheckoutCompletePage() },
        };

        public static BasePage CreatePageObject(string url)
        {
            return pages1[url]();
        }
    }
}

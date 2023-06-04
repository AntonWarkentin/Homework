using Core;

namespace Home_13
{
    internal static class PagesHelper
    {
        private static Dictionary<string, Func<BasePage>> pages = new Dictionary<string, Func<BasePage>>()
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
            return pages[url]();
        }
    }
}

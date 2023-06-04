using Core;
using Home_13.Site;

namespace Home_13.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            NavigationHelper.pages = new Dictionary<string, Func<BasePage>>()
            {
                { "https://www.saucedemo.com/", () => new LoginPage() },
                { "https://www.saucedemo.com/inventory.html", () => new InventoryPage() },
                { "https://www.saucedemo.com/cart.html", () => new CartPage() },
                { "https://www.saucedemo.com/checkout-step-one.html", () => new CheckoutStep1Page() },
                { "https://www.saucedemo.com/checkout-step-two.html", () => new CheckoutStep2Page() },
                { "https://www.saucedemo.com/checkout-complete.html", () => new CheckoutCompletePage() },
            };
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}

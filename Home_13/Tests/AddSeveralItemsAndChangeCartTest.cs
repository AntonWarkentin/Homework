using Newtonsoft.Json.Bson;
using System.Globalization;
using Core;
using Home_13.Site;

namespace Home_13.Tests
{
    public class AddSeveralItemsAndChangeCartTest : BaseTest
    {
        [Test]
        public void AddSeveralItemsAndChangeCart()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");

            var inventoryPage = (InventoryPage)loginPage.LoginAsStandartUser();
            List<double> itemPrices = new List<double>();
            itemPrices.Add(inventoryPage.OperationWithCart(0, "Add to cart"));
            itemPrices.Add(inventoryPage.OperationWithCart(1, "Add to cart"));
            itemPrices.Add(inventoryPage.OperationWithCart(5, "Add to cart"));

            var cartPage = (CartPage)inventoryPage.GoToCart();
            var pricesSum = itemPrices.Sum();
            cartPage.AssertCartCostIsEqualToSelectedItems(pricesSum);

            inventoryPage = (InventoryPage)cartPage.ContinueShopping();
            itemPrices.Remove(inventoryPage.OperationWithCart(5, "Remove"));
            itemPrices.Remove(inventoryPage.OperationWithCart(1, "Remove"));
            itemPrices.Add(inventoryPage.OperationWithCart(2, "Add to cart"));

            cartPage = (CartPage)inventoryPage.GoToCart();
            pricesSum = itemPrices.Sum();
            cartPage.AssertCartCostIsEqualToSelectedItems(pricesSum);

            var checkOutPage1 = (CheckoutStep1Page)cartPage.GoToCheckout();

            var checkOutPage2 = (CheckoutStep2Page)checkOutPage1.FillInputAndSubmit();
            checkOutPage2.ComparePrice(pricesSum);

            var checkoutComplete = (CheckoutCompletePage)checkOutPage2.FinishPurchase();
            checkoutComplete.AssertFinishMessage();

            inventoryPage = (InventoryPage)checkoutComplete.BackToProducts();
        }
    }
}
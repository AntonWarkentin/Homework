using Newtonsoft.Json.Bson;
using System.Globalization;
using Core;

namespace Home_13
{
    public class AddSeveralItemsAndConfirmTest : BaseTest
    {
        [Test]
        public void AddSeveralItemsAndConfirm()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");

            var inventoryPage = (InventoryPage)loginPage.LoginAsStandartUser();
            List<double> itemPrices = new List<double>();
            itemPrices.Add(inventoryPage.OperationWithCart(1, "Add to cart"));
            itemPrices.Add(inventoryPage.OperationWithCart(3, "Add to cart"));
            itemPrices.Add(inventoryPage.OperationWithCart(4, "Add to cart"));
            var pricesSum = itemPrices.Sum();

            var amountOfItems = inventoryPage.AmountOfItemsInCart();
            Assert.That(amountOfItems, Is.EqualTo(3));

            var cartPage = (CartPage)inventoryPage.GoToCart();

            var checkOutPage1 = (CheckoutStep1Page)cartPage.GoToCheckout();

            var checkOutPage2 = (CheckoutStep2Page)checkOutPage1.FillInputAndSubmit();
            checkOutPage2.ComparePrice(pricesSum);

            var checkoutComplete = (CheckoutCompletePage)checkOutPage2.FinishPurchase();
            checkoutComplete.AssertFinishMessage();

            inventoryPage = (InventoryPage)checkoutComplete.BackToProducts();
            amountOfItems = inventoryPage.AmountOfItemsInCart();
            Assert.That(amountOfItems, Is.EqualTo(0));
        }
    }
}
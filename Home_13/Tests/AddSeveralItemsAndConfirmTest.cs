using Newtonsoft.Json.Bson;
using System.Globalization;

namespace Home_13
{
    public class AddSeveralItemsAndConfirmTest : BaseTest
    {
        [Test]
        public void AddSeveralItemsAndConfirm()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");

            var inventoryPage = (InventoryPage)loginPage.LoginAsStandartUser();
            var item1Cost = inventoryPage.AddToCartAndGetPrice(1);
            var item2Cost = inventoryPage.AddToCartAndGetPrice(3);
            var item3Cost = inventoryPage.AddToCartAndGetPrice(4);
            var amountOfItems = inventoryPage.AmountOfItemsInCart();
            Assert.That(amountOfItems, Is.EqualTo(3));

            var cartPage = (CartPage)inventoryPage.GoToCart();

            var checkOutPage1 = (CheckoutStep1Page)cartPage.GoToCheckout();

            var checkOutPage2 = (CheckoutStep2Page)checkOutPage1.FillInputAndSubmit();
            checkOutPage2.ComparePrice(item1Cost + item2Cost + item3Cost);

            var checkoutComplete = (CheckoutCompletePage)checkOutPage2.FinishPurchase();
            checkoutComplete.AssertFinishMessage();

            inventoryPage = (InventoryPage)checkoutComplete.BackToProducts();
            amountOfItems = inventoryPage.AmountOfItemsInCart();
            Assert.That(amountOfItems, Is.EqualTo(0));
        }
    }
}
using Newtonsoft.Json.Bson;
using System.Globalization;

namespace Home_13
{
    public class AddSeveralItemsAndChangeCartTest : BaseTest
    {
        [Test]
        public void AddSeveralItemsAndChangeCart()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");

            var inventoryPage = (InventoryPage)loginPage.LoginAsStandartUser();
            var item1Cost = inventoryPage.AddToCartAndGetPrice(0);
            var item2Cost = inventoryPage.AddToCartAndGetPrice(1);
            var item3Cost = inventoryPage.AddToCartAndGetPrice(5);

            var cartPage = (CartPage)inventoryPage.GoToCart();
            cartPage.AssertCartCostIsEqualToSelectedItems(item1Cost + item2Cost + item3Cost);

            inventoryPage = (InventoryPage)cartPage.ContinueShopping();
            item3Cost = inventoryPage.DeleteFromCart(5);
            item2Cost = inventoryPage.DeleteFromCart(1);
            item2Cost = inventoryPage.AddToCartAndGetPrice(2);

            cartPage = (CartPage)inventoryPage.GoToCart();
            cartPage.AssertCartCostIsEqualToSelectedItems(item1Cost + item2Cost + item3Cost);

            var checkOutPage1 = (CheckoutStep1Page)cartPage.GoToCheckout();

            var checkOutPage2 = (CheckoutStep2Page)checkOutPage1.FillInputAndSubmit();
            checkOutPage2.ComparePrice(item1Cost + item2Cost + item3Cost);

            var checkoutComplete = (CheckoutCompletePage)checkOutPage2.FinishPurchase();
            checkoutComplete.AssertFinishMessage();

            inventoryPage = (InventoryPage)checkoutComplete.BackToProducts();
        }
    }
}
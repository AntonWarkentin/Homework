using Core;
using Home_13.Site;

namespace Home_13.Tests
{
    public class LogoutTest : BaseTest
    {
        [Test]
        public void Logout()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");
            var inventoryPage = (InventoryPage)loginPage.LoginAsStandartUser();
            loginPage = (LoginPage)inventoryPage.LogOut();
        }
    }
}
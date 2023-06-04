using Core;
using Home_13.Site;

namespace Home_13.Tests
{
    public class LockedOutUserTest : BaseTest
    {
        [Test]
        public void LockedOutUser()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");
            loginPage = (LoginPage)loginPage.LoginAsLockedOuttUser();
            loginPage.CheckLockedOutErrorMessage();
            loginPage.CloseErrorMessage();
            loginPage = (LoginPage)NavigationHelper.CreatePageObject(Browser.Instance.Driver.Url);
            loginPage.CheckErrorMessageIsClear();
        }
    }
}
using Newtonsoft.Json.Bson;
using System.Globalization;

namespace Home_13
{
    public class NotMatchingUserTest : BaseTest
    {
        [Test]
        public void NotMatchingUser()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");
            var notMatchingUser = new UserModel("aaaa", "aaa");
            loginPage.TryToLogin(notMatchingUser);
            loginPage.CheckNotMatchingErrorMessage();
            loginPage.CloseErrorMessage();
            loginPage = (LoginPage)NavigationHelper.CreatePageObject(Browser.Instance.Driver.Url);
            loginPage.CheckErrorMessageIsClear();
        }
    }
}
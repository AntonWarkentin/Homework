using Core;
using Home_13.Site;

namespace Home_13.Tests
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
            loginPage = (LoginPage)PagesHelper.CreatePageObject(Browser.Instance.Driver.Url);
            loginPage.CheckErrorMessageIsClear();
        }
    }
}
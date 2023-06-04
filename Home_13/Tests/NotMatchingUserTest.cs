using Core;

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
            loginPage = (LoginPage)NavigationHelper.CreatePageObject(Core.Browser.Instance.Driver.Url);
            loginPage.CheckErrorMessageIsClear();
        }
    }
}
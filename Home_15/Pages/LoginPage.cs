using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class LoginPage : BasePage
    {
        private By UsernameInput = By.Id("username");
        private By PasswordInput = By.Id("password");
        private By LoginButton = By.Id("Login");
        private string UsersLogin = TestContext.Parameters["Username"];
        private string UsersPassword = TestContext.Parameters["Password"];

        public SetupOneHomePage LogIn()
        {
            driver.FindElement(UsernameInput).SendKeys(UsersLogin);
            driver.FindElement(PasswordInput).SendKeys(UsersPassword);
            return (SetupOneHomePage)Browser.Instance.OpenNewPageByClick(driver.FindElement(LoginButton));
        }
    }
}
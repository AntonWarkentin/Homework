using OpenQA.Selenium;

namespace Home_13
{
    internal class LoginPage : BasePage
    {
        private const string url = "https://www.saucedemo.com/";

        private const string STANDART_USER_NAME = "standard_user";
        private const string LOCKED_OUT_USER_NAME = "locked_out_user";
        private const string PROBLEM_USER_NAME = "problem_user";
        private const string PERFORMANCE_GLITCH_USER_NAME = "performance_glitch_user";
        private const string USER_PASSWORD = "secret_sauce";
        private const string LOCKED_OUT_USER_MESSAGE = "Epic sadface: Sorry, this user has been locked out.";
        private const string NOT_MATCHING_USER_MESSAGE = "Epic sadface: Username and password do not match any user in this service";

        private By UserNameInput = By.Id("user-name");
        private By PasswordInput = By.XPath("//*[@data-test='password']");
        private By ErrorMessage = By.CssSelector(".error-message-container");
        private By LoginButton = By.CssSelector(".submit-button");
        private By CloseErrorMessageButton = By.ClassName("error-button");

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public BasePage LoginAsStandartUser()
        {
            var standartUser = new UserModel(STANDART_USER_NAME, USER_PASSWORD);
            return TryToLogin(standartUser);
        }

        public BasePage LoginAsLockedOuttUser()
        {
            var lockedOutUser = new UserModel(LOCKED_OUT_USER_NAME, USER_PASSWORD);
            return TryToLogin(lockedOutUser);
        }

        public void CheckLockedOutErrorMessage()
        {
            Assert.That(driver.FindElement(ErrorMessage).Text, Is.EqualTo(LOCKED_OUT_USER_MESSAGE));
        }
        
        public void CheckNotMatchingErrorMessage()
        {
            Assert.That(driver.FindElement(ErrorMessage).Text, Is.EqualTo(NOT_MATCHING_USER_MESSAGE));
        }

        public void CheckErrorMessageIsClear()
        {
            Assert.That(driver.FindElement(ErrorMessage).Text, Is.Empty);
        }

        public void CloseErrorMessage()
        {
            driver.FindElement(CloseErrorMessageButton).Click();
        }

        public BasePage TryToLogin(UserModel user)
        {
            driver.FindElement(UserNameInput).SendKeys(user.Name);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(LoginButton));
        }
    }
}

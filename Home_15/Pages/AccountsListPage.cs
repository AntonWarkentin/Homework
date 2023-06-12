using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class AccountsListPage : BasePage
    {
        private By FirstAccount = By.XPath("//a[@data-refid='recordId'][1]");

        public AccountViewPage OpenAccountView()
        {
            return (AccountViewPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(FirstAccount), 2, "/0015");
        }
    }
}
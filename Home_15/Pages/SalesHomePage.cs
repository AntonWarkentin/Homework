using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class SalesHomePage : BasePage
    {
        private By PageTitle = By.XPath("//span//span[@class='slds-truncate']");
        private By AccountsLink = By.XPath("//one-app-nav-bar-item-root[@data-id='Account']");
        private By AccountsChevronDown = By.XPath("//span[text()='Accounts List']/..//lightning-primitive-icon");
        private By NewAccountButton = By.XPath("//span[text()='New Account']/..//lightning-primitive-icon");

        private By ContactsLink = By.XPath($"//one-app-nav-bar-item-root[@data-id='Contact']");
        private By ContactsChevronDown = By.XPath("//span[text()='Contacts List']/..//lightning-primitive-icon");
        private By NewContactButton = By.XPath("//span[text()='New Contact']/..//lightning-primitive-icon");

        public AccountEditPage OpenNewAccountPage()
        {
            Thread.Sleep(2000);
            driver.FindElement(AccountsChevronDown).Click();
            return (AccountEditPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(NewAccountButton), 2, "?count");
        }

        public AccountsListPage OpenAccounts()
        {
            return (AccountsListPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(AccountsLink), 2, "?filterName");
        }

        public ContactEditPage OpenNewContactPage()
        {
            Thread.Sleep(2000);
            driver.FindElement(ContactsChevronDown).Click();
            return (ContactEditPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(NewContactButton), 2, "?count");
        }

        public ContactListPage OpenContacts()
        {
            return (ContactListPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(ContactsLink), 2, "?filterName");
        }
    }
}

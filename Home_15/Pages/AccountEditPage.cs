using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Home_15.Pages
{
    public class AccountEditPage : BasePage
    {
        private static string NewAccountTypeBaseXPath = "//button[contains(@aria-label, 'Type')]";
        private By AccountNameInput = By.XPath("//*[@name ='Name']");
        private By AccountPhoneInput = By.XPath("//*[@name ='Phone']");
        private By AccountTypeInput = By.XPath($"{NewAccountTypeBaseXPath}");
        private By NumberOfLocationsInput = By.XPath("//input[@name ='NumberofLocations__c']");
        private By AccountTypeOption;
        private By SaveButton = By.XPath("//*[@name ='SaveEdit']");

        public AccountViewPage CreateNewAccount(string accountName, string accountPhone, string accountType)
        {
            driver.FindElement(AccountNameInput).SendKeys(accountName);
            driver.FindElement(AccountPhoneInput).SendKeys(accountPhone);

            AccountTypeOption = By.XPath($"{NewAccountTypeBaseXPath}/ancestor::node()[2]//lightning-base-combobox-item[@data-value='{accountType}']");
            driver.FindElement(AccountTypeInput).Click();
            driver.FindElement(AccountTypeOption).Click();

            return (AccountViewPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(SaveButton), 2, "/0015");
        }

        public AccountViewPage EditAccount(string accountPhone, string accountType, string numberOfLocations)
        {
            driver.FindElement(AccountPhoneInput).Clear();
            driver.FindElement(AccountPhoneInput).SendKeys(accountPhone);

            AccountTypeOption = By.XPath($"{NewAccountTypeBaseXPath}/ancestor::node()[2]//lightning-base-combobox-item[@data-value='{accountType}']");
            driver.FindElement(AccountTypeInput).Click();
            driver.FindElement(AccountTypeOption).Click();

            driver.FindElement(NumberOfLocationsInput).Clear();
            driver.FindElement(NumberOfLocationsInput).SendKeys(numberOfLocations);

            return (AccountViewPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(SaveButton), 2, "/0015");
        }
    }
}
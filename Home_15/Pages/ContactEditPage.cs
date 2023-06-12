using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class ContactEditPage : BasePage
    {
        private By FirstNameInput = By.XPath("//*[@name ='firstName']");
        private By LastNameInput = By.XPath("//*[@name ='lastName']");
        private By EmailInput = By.XPath("//*[@name ='Email']");
        private By SearchAccountsInput = By.XPath("//label[text()='Account Name']/..//input[contains(@class,'slds-combobox__input slds-input')]");
        private By ClearAccountButton = By.XPath("//label[text()='Account Name']/..//button");
        private By AccountToChoose;
        private By SaveButton = By.XPath("//*[@name ='SaveEdit']");

        public ContactViewPage CreateNewContact(string firstName, string lastName, string accountName)
        {
            driver.FindElement(FirstNameInput).SendKeys(firstName);
            driver.FindElement(LastNameInput).SendKeys(lastName);

            AccountToChoose = By.XPath($"//li[@class='slds-listbox__item']//span[@title='{accountName}']");
            driver.FindElement(SearchAccountsInput).Click();
            driver.FindElement(AccountToChoose).Click();

            return (ContactViewPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(SaveButton), 2, "/0035");
        }

        public ContactViewPage EditContact(string accountName, string email)
        {
            driver.FindElement(ClearAccountButton).Click();
            AccountToChoose = By.XPath($"//li[@class='slds-listbox__item']//span[@title='{accountName}']");
            driver.FindElement(SearchAccountsInput).Click();
            driver.FindElement(AccountToChoose).Click();

            driver.FindElement(EmailInput).Clear();
            driver.FindElement(EmailInput).SendKeys(email);

            return (ContactViewPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(SaveButton), 2, "/0035");
        }
    }
}
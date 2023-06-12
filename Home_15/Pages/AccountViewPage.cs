using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class AccountViewPage : BasePage
    {
        private static string detailsLayout = "//div[contains(@class,'windowViewMode-normal')]";
        private By AccountNameInPopUpMessage = By.XPath("//span[contains(@class, 'toastMessage')]//div");
        private By AccountName = By.XPath("//lightning-formatted-text[@class='custom-truncate']");
        private By AccountPhone = By.XPath("//div[@class='secondaryFields']//lightning-formatted-phone//a");
        private By AccountType = By.XPath("//p[@title='Type']//..//lightning-formatted-text");
        private By OptionsDropdownButton = By.XPath("//li[contains(@class, 'slds-dropdown-trigger_click')]//button");
        private By EditButton = By.XPath("//runtime_platform_actions-action-renderer[@title='Edit']//a");
        private By DetailsButton = By.XPath($"{detailsLayout}//a[@data-label='Details']");
        private By AccountPhoneInDetails = By.XPath($"{detailsLayout}//records-record-layout-item[@field-label='Phone']//a");
        private By AccountTypeInDetails = By.XPath($"{detailsLayout}//records-record-layout-item[@field-label='Type']//lightning-formatted-text");
        private By NumOfLocationsInDetails = By.XPath($"{detailsLayout}//records-record-layout-item[@field-label='Number of Locations']//lightning-formatted-number");

        public void CheckAccountAfterCreation(string expectedName, string expectedPhone, string expectedType)
        {
            var accountNameInMessage = driver.FindElement(AccountNameInPopUpMessage).Text;
            Assert.That(accountNameInMessage, Is.EqualTo(expectedName));

            Assert.That(driver.FindElement(AccountName).Text, Is.EqualTo(expectedName));
            Assert.That(driver.FindElement(AccountPhone).Text, Is.EqualTo(expectedPhone));
            Assert.That(driver.FindElement(AccountType).Text, Is.EqualTo(expectedType));
        }

        public void CheckAccountDetails(string expectedPhone, string expectedType, string expectedNumOfLocations)
        {
            driver.FindElement(DetailsButton).Click();
           
            Assert.That(driver.FindElement(AccountPhoneInDetails).Text, Is.EqualTo(expectedPhone));
            Assert.That(driver.FindElement(AccountTypeInDetails).Text, Is.EqualTo(expectedType));
            Assert.That(driver.FindElement(NumOfLocationsInDetails).Text, Is.EqualTo(expectedNumOfLocations));
        }

        public AccountEditPage OpenEditAccount()
        {
            driver.FindElement(OptionsDropdownButton).Click();
            driver.FindElement(EditButton).Click();

            Thread.Sleep(1000);
            return new AccountEditPage();
        }
    }
}
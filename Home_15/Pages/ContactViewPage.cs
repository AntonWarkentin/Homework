using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class ContactViewPage : BasePage
    {
        private By ContactNameInPopUpMessage = By.XPath("//span[contains(@class, 'toastMessage')]//div");
        private By ContactName = By.XPath("//span[contains(@class,'custom-truncate')]");
        private By ContactsAccount = By.XPath("//p[@title='Account Name']//..//a//span");
        private By OptionsDropdownButton = By.XPath("//li[contains(@class, 'slds-dropdown-trigger_click')]//button");
        private By EditButton = By.XPath("//runtime_platform_actions-action-renderer[@title='Edit']//a");
        private By DetailsButton = By.XPath("//a[@data-label='Details']");        
        private By AccountInDetails = By.XPath("//records-record-layout-item[@field-label='Account Name']//a//span");
        private By EmailInDetails = By.XPath("//records-record-layout-item[@field-label='Email']//a");

        public void CheckContactAfterCreation(string expectedFirstName, string expectedLastName, string expectedAccount)
        {
            var contactNameInMessage = driver.FindElement(ContactNameInPopUpMessage).Text;
            var expectedWholeName = $"{expectedFirstName} {expectedLastName}";
            Assert.That(contactNameInMessage, Is.EqualTo(expectedWholeName));

            Assert.That(driver.FindElement(ContactName).Text, Is.EqualTo(expectedWholeName));
            Assert.That(driver.FindElement(ContactsAccount).Text, Is.EqualTo(expectedAccount));
        }

        public void CheckContactDetails(string expectedAccount, string expectedEmail)
        {
            driver.FindElement(DetailsButton).Click();

            Assert.That(driver.FindElement(AccountInDetails).Text, Is.EqualTo(expectedAccount));
            Assert.That(driver.FindElement(EmailInDetails).Text, Is.EqualTo(expectedEmail));
        }

        public ContactEditPage OpenEditContact()
        {
            driver.FindElement(OptionsDropdownButton).Click();
            driver.FindElement(EditButton).Click();

            Thread.Sleep(1000);
            return new ContactEditPage();
        }
    }
}
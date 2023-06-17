using OpenQA.Selenium;

namespace Home_15.Pages
{
    public class ContactListPage : BasePage
    {
        private By FirstContact = By.XPath("//a[@data-refid='recordId'][1]");

        public ContactViewPage OpenContactView()
        {
            return (ContactViewPage)Browser.Instance.OpenNewPageByClick(driver.FindElement(FirstContact), 2, "/0035");
        }
    }
}
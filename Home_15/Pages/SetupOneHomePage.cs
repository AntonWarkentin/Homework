using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;

namespace Home_15.Pages
{
    public class SetupOneHomePage : BasePage
    {
        private By SldsIconWaffleButton = By.XPath("//button[contains(@class,'slds-icon-waffle_container')]");
        private By ViewAllButton = By.XPath("//button[@aria-label='View All Applications']");
        private By SalesLinkButton = By.XPath("//p[text()='Sales']");

        public SalesHomePage OpenSales()
        {
            driver.FindElement(SldsIconWaffleButton).Click();
            driver.FindElement(ViewAllButton).Click();
            return (SalesHomePage)Browser.Instance.OpenNewPageByClick(driver.FindElement(SalesLinkButton), 5);
        }
    }
}
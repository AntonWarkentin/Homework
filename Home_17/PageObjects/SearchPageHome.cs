using Core;
using OpenQA.Selenium;

namespace Home_17.PageObjects
{
    internal class SearchPageHome : BasePage
    {
        protected string url = "https://www.booking.com/searchresults.en-gb.html";

        protected By searchInput = By.XPath("//input[@name='ss']");
        protected By searchButton = By.XPath("//button[@type='submit']");

        public SearchPageHome OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public SearchPageWithResults Search(string searchString)
        {
            driver.FindElement(searchInput).SendKeys(searchString);
            driver.FindElement(searchButton).Click();
            return new SearchPageWithResults();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Home_13
{
    public class Browser
    {
        private static Browser instance = null;
        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }

                return instance;
            }
        }

        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        private Browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }

        public BasePage OpenNewPageByClick(IWebElement element)
        {
            element.Click();
            return NavigationHelper.CreatePageObject(driver.Url);
        }

        public BasePage NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            return NavigationHelper.CreatePageObject(driver.Url);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core
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
            var implicitWait = Double.Parse(TestContext.Parameters["ImplicitWait"]);
            var downloadPath = TestContext.Parameters["DownloadPath"];

            if (downloadPath != null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);

                driver = new ChromeDriver(chromeOptions);
            }
            else
            {
                driver = new ChromeDriver();
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
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

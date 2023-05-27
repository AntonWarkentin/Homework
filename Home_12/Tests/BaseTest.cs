using OpenQA.Selenium.Chrome;

namespace Home_12.Tests
{
    public class BaseTest
    {
        protected ChromeDriver chrome;
        public string basicUrl = "http://the-internet.herokuapp.com/";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            chrome.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            chrome.Navigate().GoToUrl(basicUrl);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            chrome.Quit();
        }
    }
}

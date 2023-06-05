using OpenQA.Selenium;

namespace Home_14.Pages
{
    public class DownloadPage : BasePage
    {
        private By FilesToDownload = By.XPath("//div[@id='content']//a");
        
        public List<IWebElement> GetDownloadLinks()
        {
            return driver.FindElements(FilesToDownload).ToList();
        }
    }
}
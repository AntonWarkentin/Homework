using OpenQA.Selenium;

namespace Home_14.Pages
{
    internal class MainPage : BasePage
    {
        private By ContextMenuLink = By.LinkText("Context Menu");
        private By FileUploadLink = By.LinkText("File Upload");
        private By FileDownloadLink = By.LinkText("File Download");
        private By DynamicControlsLink = By.LinkText("Dynamic Controls");

        public BasePage OpenContextMenuPage()
        {
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(ContextMenuLink));
        }
        
        public BasePage OpenFileUploadPage()
        {
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(FileUploadLink));
        }

        public BasePage OpenFileDownloadPage()
        {
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(FileDownloadLink));
        }
        
        public BasePage OpenDynamicControlsPage()
        {
            return Browser.Instance.OpenNewPageByClick(driver.FindElement(DynamicControlsLink));
        }
    }
}

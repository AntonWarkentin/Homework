using OpenQA.Selenium;

namespace Home_14.Pages
{
    public class UploadPage : BasePage
    {
        private By UploadMenu = By.Id("file-upload");
        private By SubmitButton = By.Id("file-submit");
        private By UploadedFiles = By.Id("uploaded-files");

        public void UploadByMenu(string filePath)
        {
            driver.FindElement(UploadMenu).SendKeys(filePath);
        }

        public void ClickSubmit()
        {
            driver.FindElement(SubmitButton).Click();
        }

        public void AssertUploadedFiles(string fileName)
        {
            Assert.That(driver.FindElement(UploadedFiles).Text, Is.EqualTo(fileName));
        }
    }
}
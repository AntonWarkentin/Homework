using Home_14.Pages;
using OpenQA.Selenium.Chrome;

namespace Home_14.Tests
{
    internal class DownloadTests : BaseTest
    {
        [Test]
        public void DownloadTest()
        {
            var mainPage = (MainPage)Browser.Instance.NavigateToUrl("http://the-internet.herokuapp.com");
            var downloadPage = (DownloadPage)mainPage.OpenFileDownloadPage();
            var downloadLinks = downloadPage.GetDownloadLinks();
            var downloadFolder = TestContext.Parameters["DownloadPath"];

            var downloadedFileName = downloadLinks[4].Text;
            downloadLinks[4].Click();
            Thread.Sleep(3000);

            var directoryFiles = new DirectoryInfo(downloadFolder).GetFiles().Select(x => x.Name).ToArray();

            Assert.That(directoryFiles, Does.Contain(downloadedFileName));

            Console.WriteLine();
        }
    }
}

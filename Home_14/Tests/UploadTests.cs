using Home_14.Pages;

namespace Home_14.Tests
{
    internal class UploadTests : BaseTest
    {
        [Test]
        public void UploadTest()
        {
            var uploadPath = "D:/Users/User/source/repos/Home_1/Home_14/TestData/mklink.txt";
            var fileName = uploadPath.GetFileNameFromFullPath();

            var mainPage = (MainPage)Browser.Instance.NavigateToUrl("http://the-internet.herokuapp.com");
            var uploadPage = (UploadPage)mainPage.OpenFileUploadPage();

            uploadPage.UploadByMenu(uploadPath);
            uploadPage.ClickSubmit();
            uploadPage.AssertUploadedFiles(fileName);
        }
    }
}

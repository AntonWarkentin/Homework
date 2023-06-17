using Home_14.Pages;

namespace Home_14.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            NavigationHelper.pages = new Dictionary<string, Func<BasePage>>()
            {
                { "http://the-internet.herokuapp.com/", () => new MainPage() },
                { "http://the-internet.herokuapp.com/context_menu", () => new ContextMenuPage() },
                { "http://the-internet.herokuapp.com/upload", () => new UploadPage() },
                { "http://the-internet.herokuapp.com/download", () => new DownloadPage() },
                { "http://the-internet.herokuapp.com/dynamic_controls", () => new DynamicControlsPage() },
            };
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}

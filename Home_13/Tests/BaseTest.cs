using Core;

namespace Home_13.Tests
{
    public class BaseTest
    {
        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}

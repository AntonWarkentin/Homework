using Home_14.Pages;
using OpenQA.Selenium.Chrome;

namespace Home_14.Tests
{
    internal class DynamicControlsTests : BaseTest
    {
        [Test]
        public void DynamicControlsTest()
        {
            var mainPage = (MainPage)Browser.Instance.NavigateToUrl("http://the-internet.herokuapp.com");
            var dynamicControlsPage = (DynamicControlsPage)mainPage.OpenDynamicControlsPage();

            dynamicControlsPage.RemoveCheckboxAndAssert();
            Browser.Instance.Driver.Navigate().Refresh();
            dynamicControlsPage.EnableInputAndAssert();
        }
    }
}

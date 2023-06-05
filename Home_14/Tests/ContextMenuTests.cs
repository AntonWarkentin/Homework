using Home_14.Pages;
using OpenQA.Selenium;

namespace Home_14.Tests
{
    internal class ContextMenuTests : BaseTest
    {
        [Test]
        public void ContextMenuTest()
        {
            var expectedAlert = "You selected a context menu";

            var mainPage = (MainPage)Browser.Instance.NavigateToUrl("http://the-internet.herokuapp.com");
            var contextMenuPage = (ContextMenuPage)mainPage.OpenContextMenuPage();
            var alert = contextMenuPage.ClickContextMenuBox();

            Assert.That(alert.Text, Is.EqualTo(expectedAlert));
            alert.Accept();
        }
    }
}

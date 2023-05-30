using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace Home_12.Tests
{
    public class NotificationMessagesTests : BaseTest
    {
        [Test]
        public void NotificationMessagesTest()
        {
            NavigationHelper.NavigateAndAssertPage("Notification Messages", chrome);
            var possibleNotifications = new List<string>()
            {
                "Action unsuccesful, please try again",
                "Action successful"
            };

            var notifificationLink = chrome.FindElement(By.LinkText("Click here"));
            notifificationLink.Click();

            var notificationElement = chrome.FindElement(By.CssSelector("#flash-messages"));
            Assert.That(notificationElement.Displayed, Is.True);
            Assert.IsTrue(possibleNotifications.Contains(notificationElement.Text.TrimEnd('×').Trim()));
        }
    }
}
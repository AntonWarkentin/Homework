using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Home_12.Tests
{
    public class HoversTests : BaseTest
    {
        [Test]
        public void HoversTest()
        {
            NavigationHelper.NavigateAndAssertPage("Hovers", chrome);
            Actions action = new Actions(chrome);
            MoveToHoversAndAssert(chrome, action);
        }

        public static void MoveToHoversAndAssert(WebDriver driver, Actions action)
        {
            var hovers = driver.FindElements(By.ClassName("figure"));

            foreach (var (user, index) in hovers.Select((x, i) => (x, i)))
            {
                action.MoveToElement(hovers[index]).Perform();
                var hoversCaption = driver.FindElements(By.ClassName("figcaption")).ToList();
                AssertOneElementIsDisplayedAndOthersAreNot(index, hoversCaption);

                var hoverName = hoversCaption[index].FindElement(By.TagName("h5")).GetAttribute("innerText");
                var link = hoversCaption[index].FindElement(By.TagName("a")).GetAttribute("href");

                Assert.That(hoverName, Is.EqualTo($"name: user{index + 1}"));
                AssertUsersPageLoads(link, driver);
            }
        }

        public static void AssertUsersPageLoads(string link, WebDriver driver)
        {
            driver.Navigate().GoToUrl(link);
            var pageContent = driver.FindElement(By.TagName("h1")).GetAttribute("textContent");
            Assert.That(pageContent, Is.EqualTo("Not Found"));
            driver.Navigate().Back();
        }

        public static void AssertOneElementIsDisplayedAndOthersAreNot(int visibleElementIndex, List<IWebElement> elements)
        {
            foreach (var (element, index) in elements.Select((x, i) => (x, i)))
            {
                if (index == visibleElementIndex)
                {
                    Assert.That(element.Displayed, Is.True);
                }
                else Assert.That(element.Displayed, Is.False);
            }
        }
    }
}
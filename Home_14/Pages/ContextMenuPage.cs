using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Home_14.Pages
{
    public class ContextMenuPage : BasePage
    {
        private By ContextMenuBox = By.Id("hot-spot");

        public IAlert ClickContextMenuBox()
        {
            Actions actions = new Actions(driver);

            actions.ContextClick(driver.FindElement(ContextMenuBox)).Perform();

            return driver.SwitchTo().Alert();
        }
    }
}
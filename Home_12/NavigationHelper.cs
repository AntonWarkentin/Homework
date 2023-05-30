using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_12
{
    public static class NavigationHelper
    {
        public static void NavigateAndAssertPage(string pageTitle, WebDriver driver)
        {
            var newPage = driver.FindElement(By.LinkText(pageTitle));
            var expectedUrl = newPage.GetAttribute("href");
            newPage.Click();
            Assert.That(driver.Url, Does.Contain(expectedUrl));
        }
    }
}

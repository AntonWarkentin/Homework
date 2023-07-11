using NUnit.Framework;
using OpenQA.Selenium;

namespace Home_17.PageObjects
{
    internal class SearchPageWithResults : SearchPageHome
    {
        protected By HotelName;
        protected By HotelRating;

        public void AssertIfHotelHaveBeenFound(string hotelToFind)
        {
            HotelName = By.XPath($"//div[text()='{hotelToFind}']");
            var elements = driver.FindElements(HotelName);
            Assert.IsTrue(elements.Count == 1);
        }
        
        public void AssertHotelsRating(string hotelToFind, string expectedRank)
        {
            HotelRating = By.XPath($"//div[text()='{hotelToFind}']/ancestor::node()[7]//div[contains(@aria-label,'Scored')]");
            var element = driver.FindElement(HotelRating);
            Assert.That(expectedRank, Is.EqualTo(element.Text));
        }
    }
}
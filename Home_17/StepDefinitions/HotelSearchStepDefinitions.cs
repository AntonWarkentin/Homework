using Home_17.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Home_17.StepDefinitions
{
    [Binding]
    public class HotelSearchStepDefinitions
    {
        protected ScenarioContext _ScenarioContext;

        public HotelSearchStepDefinitions(ScenarioContext scenarioContext)
        {
            _ScenarioContext = scenarioContext;
        }

        [Given(@"Hotel with name (.*)")]
        public void GivenHotelWithNameHotelName(string hotelName)
        {
            _ScenarioContext["HotelName"] = hotelName;
        }

        [Given(@"Hotel rating is ([\d]*[.][\d]*)")]
        public void GivenHotelRatingIsHotelRating(string hotelRating)
        {
            _ScenarioContext["HotelRating"] = hotelRating;
        }

        [When(@"User searches the Hotel")]
        public void WhenUserSearchesTheHotel()
        {
            _ScenarioContext["SearchResults"] = new SearchPageHome().
                                                OpenPage().
                                                Search(_ScenarioContext["HotelName"].ToString());
        }

        [Then(@"the Hotel is on page")]
        public void ThenTheHotelIsOnPage()
        {
            var results = (SearchPageWithResults)_ScenarioContext["SearchResults"];
            var hotel = _ScenarioContext["HotelName"].ToString();
            results.AssertIfHotelHaveBeenFound(hotel);
        }

        [Then(@"Rating is equal to given")]
        public void ThenRatingIsEqualToGiven()
        {
            var results = (SearchPageWithResults)_ScenarioContext["SearchResults"];
            var hotel = _ScenarioContext["HotelName"].ToString();
            var expectedRating = _ScenarioContext["HotelRating"].ToString();
            results.AssertHotelsRating(hotel, expectedRating);
        }
    }
}

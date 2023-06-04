using Core;

namespace Home_14
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var loginPage = Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
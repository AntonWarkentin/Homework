using Allure.Net.Commons;
using Home_15.Pages;

namespace Home_15.Tests
{
    public class BaseTest
    {
        private AllureLifecycle allure;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            allure = AllureLifecycle.Instance;
        }

        [SetUp]
        public void SetUp()
        {
            NavigationHelper.pages = new Dictionary<string, Func<BasePage>>()
            {
                { "https://tms9-dev-ed.develop.my.salesforce.com/", () => new LoginPage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/setup/SetupOneHome/home", () => new SetupOneHomePage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/page/home", () => new SalesHomePage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/o/Account/list", () => new AccountsListPage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/o/Account/new", () => new AccountEditPage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/r/Account", () => new AccountViewPage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/o/Contact/list", () => new ContactListPage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/o/Contact/new", () => new ContactEditPage() },
                { "https://tms9-dev-ed.develop.lightning.force.com/lightning/r/Contact", () => new ContactViewPage() },
            };
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
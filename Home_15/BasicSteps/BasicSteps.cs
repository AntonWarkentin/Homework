using Home_15.Pages;

namespace Home_15.BasicSteps
{
    public static class BasicSteps
    {
        public static SalesHomePage OpeningSalesPage()
        {
            var loginPage = (LoginPage)Browser.Instance.NavigateToUrl("https://tms9-dev-ed.develop.my.salesforce.com");
            var setupOneHomePage = loginPage.LogIn();
            return setupOneHomePage.OpenSales();
        }
    }
}
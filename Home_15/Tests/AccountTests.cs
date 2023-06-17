using Home_15.BasicSteps;

namespace Home_15.Tests
{
    public class AccountTests : BaseTest
    {
        [Test]
        public void CreateNewAccountTest()
        {
            var newAccountName = Faker.Company.Name();
            var newAccountPhone = Faker.Phone.Number();
            var newAccountType = "Customer - Direct";

            var salesHomePage = BasicSteps.BasicSteps.OpeningSalesPage();

            var newAccountPage = salesHomePage.OpenNewAccountPage();
            var newAccount = newAccountPage.CreateNewAccount(newAccountName, newAccountPhone, newAccountType);
            newAccount.CheckAccountAfterCreation(newAccountName, newAccountPhone, newAccountType);
        }

        [Test]
        public void EditAccountTest()
        {
            var newAccountPhone = Faker.Phone.Number();
            var newAccountType = "Other";
            var newNumOfLocations = Faker.RandomNumber.Next(100).ToString();

            var salesHomePage = BasicSteps.BasicSteps.OpeningSalesPage();
            var accountsPage = salesHomePage.OpenAccounts();
            var accountPage = accountsPage.OpenAccountView();
            var accountEditPage = accountPage.OpenEditAccount();

            accountPage = accountEditPage.EditAccount(newAccountPhone, newAccountType, newNumOfLocations);
            accountPage.CheckAccountDetails(newAccountPhone, newAccountType, newNumOfLocations);
        }
    }
}
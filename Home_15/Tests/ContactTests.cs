using Home_15.Pages;

namespace Home_15.Tests
{
    public class ContactTests : BaseTest
    {
        [Test]
        public void CreateNewContactTest()
        {
            var newContactFirstName = Faker.Name.First();
            var newContactLastName = Faker.Name.Last();
            var newContactAccount = "Roga i Kopyta";

            var salesHomePage = BasicSteps.BasicSteps.OpeningSalesPage();
            var newContactPage = salesHomePage.OpenNewContactPage();

            var newContact = newContactPage.CreateNewContact(newContactFirstName, newContactLastName, newContactAccount);
            newContact.CheckContactAfterCreation(newContactFirstName, newContactLastName, newContactAccount);
        }

        [Test]
        public void EditContactTest()
        {
            var newContactAccount = "rerere";
            var newContactEmail = Faker.Internet.Email();

            var salesHomePage = BasicSteps.BasicSteps.OpeningSalesPage();
            var contactsPage = salesHomePage.OpenContacts();
            var contactPage = contactsPage.OpenContactView();
            var contactEditPage = contactPage.OpenEditContact();

            contactPage = contactEditPage.EditContact(newContactAccount, newContactEmail);
            contactPage.CheckContactDetails(newContactAccount, newContactEmail);
        }
    }
}
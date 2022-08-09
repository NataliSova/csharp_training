using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactPage();
            ContactData contactData = new ContactData("First name", "Middle name"); 
            InitNewContactCreation(contactData);
            SubmitContactCreation();
            ReturnToHomePage();
        }
    }
}

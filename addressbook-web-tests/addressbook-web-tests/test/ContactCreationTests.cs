using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("First name", "Middle name");
            app.Contacts.Create(contactData); 
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("", "");
            app.Contacts.Create(contactData);
        }
    }
}

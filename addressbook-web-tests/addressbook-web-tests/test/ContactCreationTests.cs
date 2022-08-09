using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
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

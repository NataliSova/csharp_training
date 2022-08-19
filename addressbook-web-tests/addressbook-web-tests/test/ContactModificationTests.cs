using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsSelectedContact())
            {
                ContactData contact = new ContactData("First222 name", "Middle333 name");
                app.Contacts.Create(contact);
            }
            ContactData contactData = new ContactData("First111 name", "Middle222 name");
            app.Contacts.Modify(2, contactData);
        }
    }
}

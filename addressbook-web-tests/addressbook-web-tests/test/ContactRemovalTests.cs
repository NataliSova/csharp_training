using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsSelectedContact())
            {
                ContactData contactData = new ContactData("First111 name", "Middle222 name");
                app.Contacts.Create(contactData);
            }
            app.Contacts.Remove(2);
        }
    }
}

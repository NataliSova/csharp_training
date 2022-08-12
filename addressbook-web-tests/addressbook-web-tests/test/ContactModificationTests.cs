using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactModificationTests: TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactData = new ContactData("First111 name", "Middle222 name");
            app.Contacts.Modify(2, contactData);
        }
    }
}

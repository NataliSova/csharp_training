using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("First name", "Last name");

            List<ContactData> oldcontacts = app.Contacts.GetContactList();

            app.Contacts.Create(contactData);

            List<ContactData> newcontacts = app.Contacts.GetContactList();
            oldcontacts.Add(contactData);
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("", "");

            List<ContactData> oldcontacts = app.Contacts.GetContactList();

            app.Contacts.Create(contactData);

            List<ContactData> newcontacts = app.Contacts.GetContactList();
            oldcontacts.Add(contactData);
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }
    }
}

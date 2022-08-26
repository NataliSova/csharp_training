using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("First name", "Last name");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldContact = oldContacts[0];

            app.Contacts.Create(contactData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newcontacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldContacts, newcontacts);

            foreach (ContactData contact in newcontacts)
            {
                if(!oldContacts.Any(x=>x.Id == contact.Id))
                {
                    Assert.AreEqual(contact.FirstName, contactData.FirstName);
                    Assert.AreEqual(contact.LastName, contactData.LastName);
                }
            }
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("", "");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldContact = oldContacts[0];

            app.Contacts.Create(contactData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newcontacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldContacts, newcontacts);

            foreach (ContactData contact in newcontacts)
            {
                if (!oldContacts.Any(x => x.Id == contact.Id))
                {
                    Assert.AreEqual(contact.FirstName, contactData.FirstName);
                    Assert.AreEqual(contact.LastName, contactData.LastName);
                }
            }
        }
    }
}

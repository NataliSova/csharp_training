using NUnit.Framework;
using System.Collections.Generic;

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
                ContactData contact = new ContactData("First333 name", "Last333 name");
                app.Contacts.Create(contact);
            }
            ContactData contactData = new ContactData("First444 name", "Last444 name");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldContact = oldContacts[0];

            app.Contacts.Modify(0, contactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = contactData.FirstName;
            oldContacts[0].LastName = contactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData data in newContacts)
            {
                if(data.Id == oldContact.Id)
                {
                    Assert.AreEqual(contactData.FirstName, data.FirstName);
                    Assert.AreEqual(contactData.LastName, data.LastName);
                }
            }
        }
    }
}

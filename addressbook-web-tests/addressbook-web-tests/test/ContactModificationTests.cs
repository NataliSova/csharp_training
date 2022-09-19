using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactModificationTests: ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
        if (!app.Contacts.IsSelectedContact())
            {
                ContactData contact = new ContactData("First333", "Last333");
                app.Contacts.Create(contact);
            }
            ContactData contactData = new ContactData("First444", "Last444");

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData oldContact = oldContacts[0];

            app.Contacts.ModifyContact(oldContact.Id, contactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();
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

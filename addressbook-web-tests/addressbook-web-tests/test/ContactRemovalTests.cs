using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactRemovalTests: ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contactData = new ContactData("First111", "Middle222");

            if (!app.Contacts.IsSelectedContact())
            {
                app.Contacts.Create(contactData);
            }
            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved.Id);

            int countNew = app.Contacts.GetContactCount();
            Assert.AreEqual(oldContacts.Count - 1, countNew);

            //List<ContactData> newcontacts = app.Contacts.GetContactList();
            List<ContactData> newcontacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldContacts, newcontacts);

            foreach (ContactData data in newcontacts)
            {
                Assert.AreNotEqual(data.Id, toBeRemoved.Id);
            }
        }
    }
}

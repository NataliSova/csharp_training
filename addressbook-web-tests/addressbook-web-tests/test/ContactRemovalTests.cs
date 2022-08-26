using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contactData = new ContactData("First111 name", "Middle222 name");

            if (!app.Contacts.IsSelectedContact())
            {
                app.Contacts.Create(contactData);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(0);

            int countNew = app.Contacts.GetContactCount();
            Assert.AreEqual(oldContacts.Count - 1, countNew);

            List<ContactData> newcontacts = app.Contacts.GetContactList();
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

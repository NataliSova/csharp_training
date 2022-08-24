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
                ContactData contact = new ContactData("First222 name", "Middle333 name");
                app.Contacts.Create(contact);
            }
            ContactData contactData = new ContactData("First111 name", "Middle222 name");

            List<ContactData> oldcontacts = app.Contacts.GetContactList();
            app.Contacts.Modify(0, contactData);

            List<ContactData> newcontacts = app.Contacts.GetContactList();
            oldcontacts[0].FirstName = contactData.FirstName;
            oldcontacts[0].LastName = contactData.LastName;
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }
    }
}

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
            List<ContactData> oldcontacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);

            List<ContactData> newcontacts = app.Contacts.GetContactList();
            oldcontacts.RemoveAt(0);
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }
    }
}

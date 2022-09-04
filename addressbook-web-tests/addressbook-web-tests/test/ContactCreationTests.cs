using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RendomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(30),
                    HomePhone = GenerateRandomString(10),
                    Email = GenerateRandomString(10)
                });
            }
            return contact;
        }


        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("First", "Last");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count != 0)
            {
                ContactData oldContact = oldContacts[0];
            }

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
    }
}

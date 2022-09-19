using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
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

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"C:\Users\NSova\source\repos\NataliSova\csharp_training\addressbook-web-tests\addressbook-web-tests\contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"C:\Users\NSova\source\repos\NataliSova\csharp_training\addressbook-web-tests\addressbook-web-tests\contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contactData)
        {
            //ContactData contactData = new ContactData("First", "Last");

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();

            if (oldContacts.Count != 0)
            {
                ContactData oldContact = oldContacts[0];
            }

            app.Contacts.Create(contactData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            //List<ContactData> newcontacts = app.Contacts.GetContactList();
            List<ContactData> newcontacts = ContactData.GetAll();

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

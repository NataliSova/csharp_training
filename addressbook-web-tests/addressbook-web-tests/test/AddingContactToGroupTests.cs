using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {

        [Test]
        public void AddingContactToGroupTest()
        {
            List<GroupData> groupList = GroupData.GetAll();
            if (groupList.Count == 0)
            {
                GroupData gr = new GroupData("aa");
                gr.Header = "bb";
                gr.Footer = "cc";
                app.Groups.Create(gr);
            }

            GroupData group = GroupData.GetAll()[0];

            List<ContactData> allContact = ContactData.GetAll();

            if (allContact.Count == 0)
            {
                ContactData cd = new ContactData("aa", "bb");
                cd.Address = "cc";
                cd.Email = "dd";
                app.Contacts.Create(cd);
                allContact.Add(cd);
            }
            ContactData contact = new ContactData();

            List<ContactData> oldList = group.GetContacts();
            if(oldList.Count == 0)
            {
                contact = allContact.First();
                app.Contacts.AddContactToGroup(contact, group);
                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                newList.Sort();
                oldList.Sort();
                Assert.AreEqual(oldList, newList);
            }
            else
            {
                var list = allContact.Except(oldList).ToList();
                if (list.Count > 0)
                {
                    contact = list.First();
                }
                // ContactData contact = ContactData.GetAll().Except(oldList).First();
                else
                {
                    contact = new ContactData("aa", "bb");
                    contact.Address = "cc";
                    app.Contacts.Create(contact);
                    list.Add(contact);
                }
                List<ContactData> allContactNew = ContactData.GetAll();
                foreach (ContactData cont in allContactNew)
                {
                    if (!allContact.Any(x => x.Id == cont.Id))
                    {
                        app.Contacts.AddContactToGroup(cont, group);
                    }
                }
                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                newList.Sort();
                oldList.Sort();
                Assert.AreEqual(oldList, newList);
            }
        }
    }
}

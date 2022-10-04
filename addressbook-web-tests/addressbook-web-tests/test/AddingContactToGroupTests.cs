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
            ContactData contact = new ContactData();
            List<ContactData> allContact = ContactData.GetAll();
            if (allContact.Count == 0)
            {
                contact = new ContactData("aa", "bb");
                contact.Address = "cc";
                contact.Email = "dd";
                app.Contacts.Create(contact);
                allContact.Add(contact);
            }
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count != 0)
            {
                List<ContactData> list = allContact.Except(oldList).ToList();
                if(list.Count == 0)
                {
                    contact = oldList.First();
                    app.Contacts.DeleteContactFromGroup(contact, group);
                    oldList = group.GetContacts();
                }
            }
            allContact = ContactData.GetAll();
            contact = allContact.Except(oldList).First();
            app.Contacts.AddContactToGroup(contact, group);
            oldList.Add(contact);
            List<ContactData> newList = group.GetContacts();
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}


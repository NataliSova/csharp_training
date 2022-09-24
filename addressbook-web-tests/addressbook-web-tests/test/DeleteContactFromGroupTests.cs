using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            List<GroupData> groupList = GroupData.GetAll();
            if (groupList.Count == 0)
            {
                GroupData gr = new GroupData("aa");
                gr.Header = "bb";
                gr.Footer = "cc";
                app.Groups.Create(gr);
                //groupList.Add(gr);
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
            if (oldList.Count == 0)
            {
                contact = allContact.First();
                app.Contacts.AddContactToGroup(contact, group);
                oldList = group.GetContacts();
            }
            contact = oldList.First();
            app.Contacts.DeleteContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
        //ContactData contact = ContactData.GetAll().Except(oldList).First();
    }
}

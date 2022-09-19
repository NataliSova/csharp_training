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
            GroupData group = GroupData.GetAll()[0];

            List<ContactData> oldList = group.GetContacts();
            //ContactData contact = ContactData.GetAll().Except(oldList).First();
            ContactData contact = oldList.First();

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

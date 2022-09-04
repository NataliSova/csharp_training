using NUnit.Framework;
using System;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromEditForm, fromDetails);
            Assert.AreEqual(fromEditForm.AllData, fromDetails.AllData);
        }

        [Test]
        public void TestContactNumber()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResult());
        }
    }
}

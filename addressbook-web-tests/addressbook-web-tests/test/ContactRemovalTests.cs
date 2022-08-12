using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class ContactRemovalTests: TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(2);
        }
    }
}

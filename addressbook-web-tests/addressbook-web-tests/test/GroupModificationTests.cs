using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newdata = new GroupData("bbb");
            newdata.Header = null;
            newdata.Footer = null;

            app.Groups.Modify(1, newdata);
        }
    }
}

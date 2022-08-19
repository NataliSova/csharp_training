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

            if (!app.Groups.IsSelectedGroup())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "bbb";
                group.Footer = "ccc";

                app.Groups.Create(group);
            }
            app.Groups.Modify(1, newdata);
        }
    }
}

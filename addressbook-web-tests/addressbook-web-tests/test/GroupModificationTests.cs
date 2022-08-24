using NUnit.Framework;
using System.Collections.Generic;

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

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newdata);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups[0].Name = newdata.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}

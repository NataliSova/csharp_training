using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsSelectedGroup())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "bbb";
                group.Footer = "ccc";

                app.Groups.Create(group);
            }

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newgroups = app.Groups.GetGroupList();

            oldgroups.RemoveAt(0);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}

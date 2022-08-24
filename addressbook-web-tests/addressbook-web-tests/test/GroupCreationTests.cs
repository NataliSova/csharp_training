using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}

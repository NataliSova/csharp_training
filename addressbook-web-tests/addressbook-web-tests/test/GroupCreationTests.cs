using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData oldGroup = oldGroups[0];

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldGroups, newgroups);

            foreach(GroupData gr in newgroups)
            {
                if(!oldGroups.Any(x=>x.Id == gr.Id))
                {
                    Assert.AreEqual(gr.Name, group.Name);
                }
            }
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData oldGroupsCreate = oldGroups[0];

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldGroups, newgroups);

            foreach (GroupData gr in newgroups)
            {
                if (!oldGroups.Any(x => x.Id == gr.Id))
                {
                    Assert.AreEqual(gr.Name, group.Name);
                }
            }
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData oldGroupsCreate = oldGroups[0];

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldGroups, newgroups);

            foreach (GroupData gr in newgroups)
            {
                if (!oldGroups.Any(x => x.Id == gr.Id))
                {
                    Assert.AreEqual(gr.Name, group.Name);
                }
            }
        }
    }
}

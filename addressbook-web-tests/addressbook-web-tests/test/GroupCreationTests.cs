using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();  
            for(int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
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

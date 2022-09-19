using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldGroups, newgroups);

            foreach(GroupData group in newgroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

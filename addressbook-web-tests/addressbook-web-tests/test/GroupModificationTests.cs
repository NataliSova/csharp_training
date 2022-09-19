using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
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

            //List<GroupData> oldgroups = app.Groups.GetGroupList();
            List<GroupData> oldgroups = GroupData.GetAll();

            GroupData oldData = oldgroups[0];

            app.Groups.Modify(oldData.Id, newdata);

            Assert.AreEqual(oldgroups.Count, app.Groups.GetGroupCount());

            //List<GroupData> newgroups = app.Groups.GetGroupList();
            List<GroupData> newgroups = GroupData.GetAll();

            oldgroups[0].Name = newdata.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

            foreach(GroupData group in newgroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newdata.Name, group.Name);
                }
            }
        }
    }
}

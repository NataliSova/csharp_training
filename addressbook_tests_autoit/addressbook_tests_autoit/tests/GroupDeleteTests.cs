using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeleteTests : TestBase
    {
        [Test]
        public void TestGroupDelete()
        {
            GroupData newGroup = new GroupData()
            {
                Name = "test1"
            };
            app.Groups.AddGroup(newGroup);

            List<GroupData> oldGroups = app.Groups.GetAllGroupList();
            //GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(newGroup);


            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }

    }
}

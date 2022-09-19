using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\NSova\source\repos\NataliSova\csharp_training\addressbook-web-tests\addressbook-web-tests\groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i < range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] line = File.ReadAllLines(@"C:\Users\NSova\source\repos\NataliSova\csharp_training\addressbook-web-tests\addressbook-web-tests\groups.csv");
            foreach(string l in line)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"C:\Users\NSova\source\repos\NataliSova\csharp_training\addressbook-web-tests\addressbook-web-tests\groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"C:\Users\NSova\source\repos\NataliSova\csharp_training\addressbook-web-tests\addressbook-web-tests\groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData oldGroup = oldGroups[0];

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = GroupData.GetAll();
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

        [Test]
        public void TestDBConnect()
        {
            //DateTime start = new DateTime();
            //List<GroupData> fromUi = app.Groups.GetGroupList();
            //DateTime end = new DateTime();
            //System.Console.Out.WriteLine(end.Subtract(start));
            //start = new DateTime();     
            //List<GroupData> fromDb = GroupData.GetAll();
            //end = new DateTime();
            //System.Console.Out.WriteLine(end.Subtract(start));

            foreach(ContactData contact in GroupData.GetAll()[0].GetContacts()){
                System.Console.Out.WriteLine(contact.Deprecated);
            };
        }
    }
}

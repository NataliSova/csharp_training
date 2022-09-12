using WebAddressbookTests;
using WebAddressbookTests.test;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filenme = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();
            if(type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "excel")
                {
                    GroupWriteToExcelFile(groups, filenme);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filenme);

                    if (format == "csv")
                    {
                        GroupWriteToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        GroupWriteToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        GroupWriteToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }
            if(type == "contacts")
            {
                for(int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(100),
                        MobilePhone = TestBase.GenerateRandomString(100),
                        Email = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "excel")
                {
                    ContactWriteToExcelFile(contacts, filenme);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filenme);

                    if (format == "csv")
                    {
                        ContactWriteToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        ContactWriteToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        ContactWriteToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }
            
            
        }

        static void GroupWriteToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach(GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name ;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit(); 
        }

        static void GroupWriteToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void GroupWriteToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void GroupWriteToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void ContactWriteToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.FirstName;
                sheet.Cells[row, 2] = contact.LastName;
                sheet.Cells[row, 3] = contact.Address;
                sheet.Cells[row, 4] = contact.MobilePhone;
                sheet.Cells[row, 5] = contact.Email;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void ContactWriteToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${4},${5}",
                    contact.FirstName, contact.LastName, contact.Address, contact.MobilePhone, contact.Email));
            }
        }

        static void ContactWriteToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void ContactWriteToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
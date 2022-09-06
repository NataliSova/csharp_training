using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
    {
        public ContactHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        public ContactHelper Create(ContactData contactData)
        {
            manager.Navigator.GoToContactPage();
            InitNewContactCreation(contactData);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public int GetNumberOfSearchResult()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactDetails(index);

            string text = driver.FindElement(By.CssSelector("div#content")).Text;

            //string name = driver.FindElement(By.CssSelector("div#content b")).Text;

            return new ContactData()
            {
                AllData = text
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhone = cells[5].Text;
            string allEmail = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhone,
                AllEmails = allEmail
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        private void InitContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public void InitContactModification(int index)
        {
               driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if(contactCache == null)
            {
                manager.Navigator.OpenHomePage();

                contactCache = new List<ContactData>();

                ICollection<IWebElement> contacts = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement contact in contacts)
                {
                    ICollection<IWebElement> listTdElem = contact.FindElements(By.CssSelector("td"));

                    List<string> list = new List<string>();
                    int count = 0;
                    foreach (var elemTd in listTdElem)
                    {
                        if(count == 0)
                        {
                            list.Add(elemTd.FindElement(By.TagName("input")).GetAttribute("id"));
                        }

                        list.Add(elemTd.Text);
                        count++;
                    }
                    if (list.Count > 0)
                        contactCache.Add(new ContactData(list[3], list[2])
                        {
                            Id = list[0]
                        });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.OpenHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper Modify(int c, ContactData contactData)
        {
            manager.Navigator.OpenHomePage();
            //EditSelectContact(c);
            InitContactModification(c);
            InitNewContactCreation(contactData);
            SubmitContactUpdate();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(int c)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(c);
            //EditSelectContact(c);
            SubmitContactDelete();
            return this;
        }
        private ContactHelper SubmitContactDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper EditSelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ (index+2) +"]/td[8]/a/img")).Click();
            return this;
        }

        public bool IsSelectedContact()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitNewContactCreation(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("middlename"), contactData.MiddleName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("nickname"), contactData.Nickname);
            driver.FindElement(By.Name("photo")).SendKeys(@"C:\\Temp\\tsvety-_83_.jpg");
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.HomePhone);
            Type(By.Name("mobile"), contactData.MobilePhone);
            Type(By.Name("work"), contactData.WorkPhone);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("homepage"), contactData.Homepage);
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            //Type(By.Name("byear"), contactData.Year);
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("2");
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("February");
            //Type(By.Name("ayear"), contactData.Year);
            Type(By.Name("address2"), contactData.SecondaryAddress);
            Type(By.Name("phone2"), contactData.SecondaryHome);
            Type(By.Name("notes"), contactData.SecondaryNotes);
            return this;
        }
    }
}

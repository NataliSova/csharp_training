using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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
            EditSelectContact(c);
            InitNewContactCreation(contactData);
            SubmitContactUpdate();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(int c)
        {
            manager.Navigator.OpenHomePage();
            EditSelectContact(c);
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
            Type(By.Name("home"), contactData.HomeTelephone);
            Type(By.Name("mobile"), contactData.MobileTelephone);
            Type(By.Name("work"), contactData.WorkTelephone);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("homepage"), contactData.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            Type(By.Name("byear"), contactData.Year);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("2");
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("February");
            Type(By.Name("ayear"), contactData.Year);
            Type(By.Name("address2"), contactData.SecondaryAddress);
            Type(By.Name("phone2"), contactData.SecondaryHome);
            Type(By.Name("notes"), contactData.SecondaryNotes);
            return this;
        }
    }
}

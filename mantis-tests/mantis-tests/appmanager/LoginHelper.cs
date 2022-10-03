using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData accountData)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(accountData))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("username"), accountData.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), accountData.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("dropdown-toggle"));
        }

        public bool IsLoggedIn(AccountData accountData)
        {
            return IsLoggedIn() && GetLoggetUserName() == accountData.Name;
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.CssSelector("aspam.user-info")).Text;
            return text.Substring(1, text.Length);
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElements(By.LinkText("a.dropdown-toggle"))[1].Click();
            }
        }
    }
}

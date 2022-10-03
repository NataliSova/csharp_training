using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;
        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenMenu()
        {
            OpenHomePage();
            OpenMenuClick();
            GoToManagement();
            GoToManagementProject();
        }

        private void OpenMenuClick()
        {
            driver.FindElement(By.XPath("//button[@id='menu-toggler']")).Click();
            //driver.SwitchTo().Alert().Accept();
        }

        private void GoToManagementProject()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.25.2/account_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.25.2/account_page.php");
        }
        private void GoToManagement()
        {
            driver.FindElement(By.XPath("//i[@class='fa fa-gears menu-icon']")).Click();
        }
    }
}

using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        private string baseURL;
        public ProjectManagementHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void CreateProject(ProjectData project)
        {
            OpenCreateProjectPage();
            CreateProjectClick();
            FillProjectForm(project);
            SubmitProjectAdd();
        }

        public void RemoveProject(ProjectData project)
        {
            OpenAllProjectPage();
            SelectProject(project);
            ProjectModificationClick(project.Id);
            DeleteProjectClick();
            DeleteProjectYes();
        }

        public void ProjectModificationClick(string id)
        {
            Regex rx = new Regex(@"manage_proj_edit_page.php?project_id=" + id);
            driver.FindElement(By.XPath("//a[@href='" + rx + "']")).Click();
        }

        private void DeleteProjectClick()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void DeleteProjectYes()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SelectProject(ProjectData project)
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a"));
        }

        public void OpenCreateProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_create_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_create_page.php");
        }

        public void OpenAllProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }

        private void CreateProjectClick()
        {
            //driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")).Click();
            //driver.FindElement(By.XPath("//button[contains(.,'Создать новый проект')]")).Click();
            //driver.FindElement(By.XPath("//button[contains(text(),'Создать новый проект')]")).Click();


            var allButtons = driver.FindElements(By.TagName("form")); 
            var button = allButtons[0];
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }
        public void SubmitProjectAdd()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public List<ProjectData> GetAllProjects()
        {
            List<ProjectData> accounts = new List<ProjectData>();
            //IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_proj_page.php";
            //IList<IWebElement> rows = driver.FindElements(By.Name("table"));
            IList<IWebElement> rows = driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new ProjectData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.CssSelector("input.button")).Click();
            return driver;
        }
    }
}

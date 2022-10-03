using OpenQA.Selenium;
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
            if (driver.Url == baseURL + "/mantisbt-2.25.2/manage_proj_create_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.25.2/manage_proj_create_page.php");
        }

        public void OpenAllProjectPage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.25.2/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.25.2/manage_proj_page.php");
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
    }
}

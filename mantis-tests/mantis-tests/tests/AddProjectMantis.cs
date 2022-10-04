using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AddProjectMantis: AuthTestBase
    {
        [Test]
        public void TestAddProjectMantis()
        {
            //AccountData account = new AccountData("administrator", "root");

            app.ManagementMenu.OpenMenu();

            ProjectData project = new ProjectData()
            {
                Name = "test"
            };
            
            List<ProjectData> oldProjects = app.ProjectManagement.GetAllProjects();

            ProjectData existingAccount = oldProjects.Find(x => x.Name == project.Name);

            if (existingAccount != null)
            {
                app.ProjectManagement.RemoveProject(existingAccount);
            }

            app.ProjectManagement.CreateProject(project);

            //Assert.AreEqual(oldProjects.Count + 1, app.Groups.GetGroupCount());

            List<ProjectData> newProject = app.ProjectManagement.GetAllProjects();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }

        [Test]
        public void AddNewProgectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Name = "NewProject"
            };

            app.API.CreateNewProject(account, project);
        }
    }
}

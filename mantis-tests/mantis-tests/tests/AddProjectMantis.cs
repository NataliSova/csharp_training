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
            
            List<ProjectData> oldProjects = ProjectData.GetAll();
            int i = 0;
            foreach (ProjectData data in oldProjects)
            {
                if(data.Name == "test")
                {
                    project.Name = data.Name + i;
                }
                i++;
            }
            //ProjectData oldProject = oldProjects[0];

            app.ProjectManagement.CreateProject(project);

            //Assert.AreEqual(oldProjects.Count + 1, app.Groups.GetGroupCount());

            List<ProjectData> newProject = ProjectData.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }
    }
}

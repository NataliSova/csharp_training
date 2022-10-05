using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class DeleteProjectMantis: AuthTestBase
    {
        [Test]
        public void TestDeleteProjectMantis()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            //List<ProjectData> oldProjects = app.ProjectManagement.GetAllProjects();
            List<ProjectData> oldProjects = app.API.GetAllProjectsApi(account);
            if (oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData();
                project.Name = "aaa";
                app.ProjectManagement.CreateProject(project);

               // ProjectData project = new ProjectData()
                //{
                    //Name = "NewProject"
                //};

                //app.API.CreateNewProject(account, project);
            }

            //oldProjects = app.ProjectManagement.GetAllProjects();
            oldProjects = app.API.GetAllProjectsApi(account);

            ProjectData toBeRemoved = oldProjects[0];

            app.ProjectManagement.RemoveProject(toBeRemoved);

            //List<ProjectData> newProject = app.ProjectManagement.GetAllProjects();
            List<ProjectData> newProject = app.API.GetAllProjectsApi(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }
    }
}

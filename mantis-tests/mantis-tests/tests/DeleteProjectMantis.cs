﻿using NUnit.Framework;
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
            List<ProjectData> oldProjects = ProjectData.GetAll();
            if(oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData();
                project.Name = "aaa";
                app.ProjectManagement.CreateProject(project);
            }

            oldProjects = ProjectData.GetAll();

            ProjectData toBeRemoved = oldProjects[0];

            app.ProjectManagement.RemoveProject(toBeRemoved);

            //Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<ProjectData> newProject = ProjectData.GetAll();

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }
    }
}
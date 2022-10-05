using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreatenewIssue(AccountData account, ProjectData projectData, IssueData data)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = data.Summary;
            issue.description = data.Description;
            issue.category = data.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = projectData.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData proj= new Mantis.ProjectData();
            proj.name = project.Name;
            client.mc_project_add(account.Name, account.Password, proj);
        }

        public List<ProjectData> GetAllProjectsApi(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            //Mantis.ProjectData proj = new Mantis.ProjectData();
            List<ProjectData> accounts = new List<ProjectData>();

            Mantis.ProjectData[] projects  = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach(Mantis.ProjectData proj in projects)
            {
                accounts.Add(new ProjectData()
                {
                    Name = proj.name,
                    Id = proj.id
                });
            }
            return accounts;
           
        }
    }
}

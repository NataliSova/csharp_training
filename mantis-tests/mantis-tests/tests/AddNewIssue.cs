using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue: TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectData = new ProjectData()
            {
                Id = "15"
            };

            IssueData issueData = new IssueData() {
                Summary = "some text",
                Description = "some long text",
                Category = "General"
                };

            app.API.CreatenewIssue(account, projectData, issueData);
        }
    }
}

using NUnit.Framework;
using System;
using System.Text;

namespace mantis_tests
{
    public class TestBase
    {
        
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

    }
}

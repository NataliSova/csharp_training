﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}

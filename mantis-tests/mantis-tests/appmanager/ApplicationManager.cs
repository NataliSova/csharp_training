using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected LoginHelper login;
        protected ManagementMenuHelper managementMenu;
        protected ProjectManagementHelper projectManagement;

        private string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            
            baseURL = "http://localhost";
            //Registration = new RegistrationHelper(this);
            //Ftp = new FtpHelper(this);
            login = new LoginHelper(this);
            managementMenu = new ManagementMenuHelper(this, baseURL);
            projectManagement = new ProjectManagementHelper(this, baseURL);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance() 
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/account_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        { 
            get { return driver; } 
        }
        public LoginHelper Login
        {
            get { return login; }
        }
        public ManagementMenuHelper ManagementMenu
        {
            get { return managementMenu; }
        }
        public ProjectManagementHelper ProjectManagement
        {
            get { return projectManagement; }
        }

    }
}

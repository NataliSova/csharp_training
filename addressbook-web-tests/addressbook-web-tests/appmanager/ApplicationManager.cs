using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private string baseURL;

        protected LoginHelper loginHelper;
        protected NavigatorHelper navigatorHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigatorHelper = new NavigatorHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
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
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        { 
            get { return driver; } 
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigatorHelper Navigator
        {
            get { return navigatorHelper; }
    
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }
    }
}

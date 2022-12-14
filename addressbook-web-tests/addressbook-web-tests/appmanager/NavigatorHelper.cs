using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigatorHelper : HelperBase
    {
        private string baseURL;
        public NavigatorHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if(driver.Url== baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void GoToGroupsPage()
        {
            if(driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

    }
}

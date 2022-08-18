using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class LoginTests : TestBase
{
        [Test]
        public void LoginWithValidCridantials()
        {
            app.Auth.Logout();

            //action
            AccountData accountData = new AccountData("admin", "secret");
            app.Auth.Login(accountData);

            Assert.IsTrue(app.Auth.IsLoggedIn(accountData));

        }

        [Test]
        public void LoginInvalidCridantials()
        {
            app.Auth.Logout();
             
            //action
            AccountData accountData = new AccountData("admin", "12345");
            app.Auth.Login(accountData);

            Assert.IsFalse(app.Auth.IsLoggedIn(accountData));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_webtest
{
    [TestFixture]
    public class LoginTests : TestBase
    {
       [Test]
       public void LoginWithValidCredentials() 
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(new AccountData("admin", "secret"));
            
            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWitInhValidCredentials()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(new AccountData("admin", "secret"));

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }



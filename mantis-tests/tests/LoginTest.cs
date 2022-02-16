using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{

    [TestFixture]
    public class LoginTests : TestBase
    {

        [Test]
        public void TestLogin()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            app.Login.Logout();

            app.Login.Login(account);

        }

    }
}
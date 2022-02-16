using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace mantis_tests
    {
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()

        {
            AccountData account = new AccountData()
            { 
            Name = "administrator",
            Password = "root",

            };
            
            app.Login.Login(account);

        }
    }

}
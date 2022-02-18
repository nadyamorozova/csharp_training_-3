using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]

        public void setUpConfig()
        {
            app.Ftp.BackupFile("config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("config/config_inc.php", localFile);
            }

        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {

                Name = "teeestt",
                Password = "password",
                Email = "testuser111111@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();

            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            app.Registration.Register(account);
        }

        [Test]
        public void GetAccountsList()
        {
            List<AccountData> accounts = app.Admin.GetAllAccounts();

            //[TestFixtureTearDown]
            //public void restoreConfig()
            //{
            //    app.Ftp.RestoreBackupFile("/config_inc.php");
            //}

        }
    }
}


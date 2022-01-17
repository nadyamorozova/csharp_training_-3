using NUnit.Framework;


namespace addressbook_webtest
{
    public class TestBase
    {
        
        protected ApplicationManager app;
        [Test]
        public void LoginWithInValidCredentials()
        {
           
            app.Auth.Logout();
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }

        [SetUp]
        public void SetupApplicationManager()

        {
            app = ApplicationManager.GetInstance();
         
        }
    }
}

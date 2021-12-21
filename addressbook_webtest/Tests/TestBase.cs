using addressbook_webtest.AppManager;
using addressbook_webtest.Model;
using NUnit.Framework;


namespace addressbook_webtest.Test
{
    public class TestBase
    {
        
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();  
        }
    }
  }

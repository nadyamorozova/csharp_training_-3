using NUnit.Framework;


namespace addressbook_webtest
{
    public class TestBase
    {
        
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()

        {
            app = ApplicationManager.GetInstance();
         
        }
    }
}

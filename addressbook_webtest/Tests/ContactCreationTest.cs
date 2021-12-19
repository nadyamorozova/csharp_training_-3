using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {

            
            app.Contacts.InitContactCreation();
            app.Contacts.FillContactForm(new Contact("Nadya", "Morozova"));
            app.Contacts.SubmitContactCreation();
            app.Groups.ReturnToGroupsPage();
         }
    }
}


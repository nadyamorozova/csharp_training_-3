using addressbook_webtest.Model;
using NUnit.Framework;

namespace addressbook_webtest.Test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {

            ContactData contacts = new ContactData("Nadya");
            contacts.LastName = "Morozova";
            contacts.Address = "Verbnaya street";
            contacts.Email = "ya@ya.ru";
            app.Contacts.Create(contacts);
          
        
        }
    }
}


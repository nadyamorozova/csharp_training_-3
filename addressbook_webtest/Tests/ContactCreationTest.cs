using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_webtest
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {

            ContactData contacts = new ContactData("Nadya");
            contacts.LastName = "Morozova";
            contacts.Address = "Verbnaya street";
            contacts.Email = "ya@ya.ru";

            app.Contacts.Create(contacts)
        }
    }
}

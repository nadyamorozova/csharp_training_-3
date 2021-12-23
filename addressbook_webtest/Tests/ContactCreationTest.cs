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

            ContactData contacts = new ContactData("Nadya");
            ContactData.LastName = "Morozova";
            ContactData.Address = "Verbnaya street";
            ContactData email = "ya@ya.ru";

            app.Contacts.Create(contacts);

        }
    }
}

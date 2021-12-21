using NUnit.Framework;
using addressbook_webtest.Model;

namespace addressbook_webtest.Test
{
    [TestFixture]
    public class ContactModificationTest : TestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData newData = new ContactData("Nadia");
            newData.LastName = "Morozova";
            newData.Address = "Verbosti street";
            newData.Mobile = "78965";
            newData.Email = "ya@ya.ru";
            app.Contacts.Modify(newData);               
        }
    }
}

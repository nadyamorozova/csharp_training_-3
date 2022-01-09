using NUnit.Framework;


namespace addressbook_webtest
{
    [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData newData = new ContactData("Nadia");
            newData.LastName = "Morozova";
            newData.Address = "Verbosti street";
            newData.Email = "ya@ya.ru";
            app.Contacts.Modify(newData);               
        }
    }
}

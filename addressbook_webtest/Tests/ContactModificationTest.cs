using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData newData = (new ContactData("J", "Lo"));
            newData.Lastname = "OOO";
        

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.Modify(2, newData);
            List<ContactData> newContact = app.Contacts.GetContactList();

            
            oldContact[0].Lastname = newData.Lastname;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);

        }
    }
}

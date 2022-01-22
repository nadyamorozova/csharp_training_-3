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
            ContactData oldData = oldContact[0];

            app.Contacts.Modify(newData);

            Assert.AreEqual(oldContact.Count, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactList();


            oldContact[0].Lastname = newData.Lastname;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}

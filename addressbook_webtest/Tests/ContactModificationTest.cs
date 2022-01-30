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
            ContactData newData = new ContactData("Rename");
            newData.Lastname = "Lopez";
            newData.Address = "Russia";
            

            List<ContactData> oldContact = app.Contacts.GetContactList();
            ContactData oldData = oldContact[0];

            app.Contacts.Modify(newData);

            //Assert.AreEqual(oldContact.Count, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactList();


            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;

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

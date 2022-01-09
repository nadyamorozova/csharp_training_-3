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
            ContactData newData = new ContactData("Js", "Los");
            newData.Middlename = "Sergeevnas";

            app.Contacts.IsContactPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(1, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
    }
}

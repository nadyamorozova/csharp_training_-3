using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_webtest
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {

            ContactData contacts = new ContactData("J","Lo");
            contacts.Firstname = "Lora";
            contacts.Lastname = "Morozova";
            contacts.Address = "Arbat";
            contacts.Mobile = "777";
            contacts.Email = "ya@ya.ru";


            List<ContactData> oldContacts = app.Contacts.GetContactList();
            

            app.Contacts.Create(contacts);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            
            oldContacts.Add(contacts);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

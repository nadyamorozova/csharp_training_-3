﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_webtest
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        private object newContacts;

        [Test]
        public void ContactCreationTest()
        {

            ContactData contacts = (new ContactData("J","Lo"));
            contacts.Middlename = "Sergeevna";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            

            app.Contacts.Create(contacts);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contacts);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

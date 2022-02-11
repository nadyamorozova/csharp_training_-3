﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace addressbook_webtest
{
    [TestFixture]
    public class ContactModificationTest : ContactTestBase
    {
  

        [Test]
        public void ContactModificationTests()
        {
            ContactData newData = new ContactData("Rename");
            newData.Lastname = "Lopez";
            newData.Address = "Russia";


            app.Contacts.IsContactPresent();

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeModified = oldContact[0];
            ContactData oldData = oldContact[0];

            app.Contacts.Modify(toBeModified,newData);

            Assert.AreEqual(oldContact.Count, app.Contacts.GetContactCount());

            List<ContactData> newContact = ContactData.GetAll();

            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, toBeModified.Lastname);
                    Assert.AreEqual(newData.Lastname, toBeModified.Firstname);
                }
            }
        }
    }
}
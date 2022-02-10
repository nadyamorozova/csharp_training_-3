using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
namespace addressbook_webtest
{
    [TestFixture]
    public class ContactInformationTest : ContactTestBase
    {
        [Test]
        public void ContactInformationTests()
        {

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm();

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address.Trim());
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }

        [Test]
        public void ContactDetailTest()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetailsForm();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm();


            //Assert.AreEqual(fromDetails, fromForm.AllDetails);
        }
    }
}
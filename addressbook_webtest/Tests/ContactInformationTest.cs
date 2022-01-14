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
    public class ContactInformationTest: AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
           ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
           ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            //verification

        }
    }
}

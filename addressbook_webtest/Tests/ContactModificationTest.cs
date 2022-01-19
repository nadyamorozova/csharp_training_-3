﻿using NUnit.Framework;
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

            app.Contacts.IsContactPresent();
            app.Contacts.Modify(2, newData);
        }
    }
}

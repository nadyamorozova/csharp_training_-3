using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_webtest.Test
{
     
    [TestFixture]
    public class ContactRemovalTest : TestBase
    {

        [Test]
        public void ContactRemovalTests()
        {
            app.Contacts.Remove(1);
        }
    }
}
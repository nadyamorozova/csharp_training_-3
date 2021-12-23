using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_webtest
{
     
    [TestFixture]
    public class ContactRemovalTest : AuthTestBase
    {

        [Test]
        public void ContactRemovalTests()
        {
            app.Contacts.IsContactPresent();
            app.Contacts.Remove(1);
        }
    }
}
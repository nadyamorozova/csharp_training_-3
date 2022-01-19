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
            app.Contacts.Remove(2);
        } 
    } 
}
//            List<ContactData> oldContacts = app.Contacts.GetContactList();

            
//            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

//            List<ContactData> newContacts = app.Contacts.GetContactList();

//            oldContacts.RemoveAt(0);
//            Assert.AreEqual(oldContacts, newContacts);
//         }
//    }
//}
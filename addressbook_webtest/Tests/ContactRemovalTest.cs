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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(1);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    } 
}


            
 
      
          
         

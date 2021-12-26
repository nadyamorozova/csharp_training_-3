using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_webtest
{
    [TestFixture]
   public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificatinTests()
        {
            GroupData newData = new GroupData("Modify");
            newData.Header = null;
            newData.Footer = null;


            app.Groups.Modify(1, newData);

        }
    }
}
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
        public void GroupModificationTest()
        {
            GroupData newData = (new GroupData("tree"));
            newData.Header = "null";
            newData.Footer = "null";


            app.Groups.IsGroupPresent();
            app.Groups.Modify(1, newData);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_webtest
{
    [TestFixture]
   public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = (new GroupData("mob"));
            newData.Header = "one";
            newData.Footer = "two";

            app.Groups.Modify(1, newData);

        }
    }
}
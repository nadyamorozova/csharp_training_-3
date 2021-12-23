using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_webtest.Test
{
    [TestFixture]
   public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificatinTests()
        {
            GroupData newData = new GroupData("Modify");
            newData.Header = "Modify ";
            newData.Footer = "Modify";


            app.Groups.Modify(1, newData);

        }
    }
}
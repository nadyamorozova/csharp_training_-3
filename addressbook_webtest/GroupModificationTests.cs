﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
   public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificatinTests()
        {
            GroupData newData = new GroupData("Dec");
            newData.Header = "Jan";
            newData.Footer = "Feb";

            app.Groups.Modify(1, newData);
        }
   }
}

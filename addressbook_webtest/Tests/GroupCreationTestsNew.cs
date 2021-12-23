using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_webtest.Model;
using NUnit.Framework;

namespace addressbook_webtest.Test
{
    [TestFixture]
    public class GroupCreationTestsNew : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("December");
            group.Header = "January";
            group.Footer = "February";
            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("");
            groupData.Header = "";
            groupData.Footer = "";
        }
    }
}

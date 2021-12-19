using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
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
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
        }
    }
}

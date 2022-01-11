using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_webtest
{
    [TestFixture]
    public class GroupCreationTestsNew : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = (new GroupData("December")));
            group.Header = "January";
            group.Footer = "February";


            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("");
            groupData.Header = "";
            groupData.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}

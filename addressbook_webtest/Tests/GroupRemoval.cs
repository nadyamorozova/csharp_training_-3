using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_webtest
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
      
        [Test]
        public void GroupRemovalTest()

        {
            app.Groups.IsGroupPresent();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            {
                Assert.AreNotEqual(Group.Id, toBeRemoved.Id);
            }

        }
    }
}

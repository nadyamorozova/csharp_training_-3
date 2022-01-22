using System;
using System.Collections.Generic;
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
             List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
          
            Assert.AreEqual(oldGroups, newGroups);


          //Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            //GroupData toBeRemoved = oldGroups[0];
            //oldGroups.RemoveAt(0);           
            //foreach (GroupData group in newGroups)
            //{
            //    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }


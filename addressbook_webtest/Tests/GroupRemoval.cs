﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_webtest
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()

        {

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(ToBeRemoved);


            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll();


            oldGroups.RemoveAt(0);


            Assert.AreEqual(oldGroups, newGroups);


            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);

            }
        }
        
    }
    
}


﻿using System;
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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = (GenerateRandomString(100)),
                    Footer = (GenerateRandomString(100))
                });

            }
            return groups;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTests(GroupData groupData)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

        //[Test]
        //public void EmptyGroupCreationTest()
        //{
        //    GroupData group = (new GroupData(""));
        //    group.Header = "";
        //    group.Footer = "";


        //    List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    app.Groups.Create(group);

        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

        //    List<GroupData> newGroups = app.Groups.GetGroupList();
           
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);


//[Test]

//public void BadNameGroupCreationTest()
//{
//    GroupData group = (new GroupData("x'x"));
//    group.Header = "";
//    group.Footer = "";

//    List<GroupData> oldGroups = app.Groups.GetGroupList();

//    app.Groups.Create(group);

//    Assert.AreEqual(oldGroups.Count +1, app.Groups.GetGroupCount());


//    List<GroupData> newGroups = app.Groups.GetGroupList();
//    oldGroups.Add(group);
//    oldGroups.Sort();
//    newGroups.Sort();
//    Assert.AreEqual(oldGroups, newGroups);


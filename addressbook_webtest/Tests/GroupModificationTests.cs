using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_webtest
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = (new GroupData("tree"));
            newData.Header = "null";
            newData.Footer = "null";


            app.Groups.IsGroupPresent();
            app.Groups.Modify(1, newData);
        }

        //List<GroupData> oldGroups = app.Groups.GetGroupList();
        //GroupData oldData = oldGroups[0];

        //Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

        //List<GroupData> newGroups = app.Groups.GetGroupList();
        //oldGroups[0].Name = newData.Name;
        //oldGroups.Sort();
        //newGroups.Sort();

        //Assert.AreEqual(oldGroups, newGroups);
        //foreach (GroupData group in newGroups)
        //{
        //    if (group.Id == oldData.Id)
        //        Assert.AreEqual(newData.Name, group.Name);
    }
}
            
        
    

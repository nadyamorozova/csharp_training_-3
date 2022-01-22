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
            GroupData newData = (new GroupData("Modify"));
            newData.Header = "Test";
            newData.Footer = "Drive";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(1, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}



        
        //GroupData oldData = oldGroups[0];

        //Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
        //foreach (GroupData group in newGroups)
        //{
        //    if (group.Id == oldData.Id)
        //        Assert.AreEqual(newData.Name, group.Name);
    

            
        
    

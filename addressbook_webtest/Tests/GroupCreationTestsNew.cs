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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
           
            GroupData group = new GroupData("December");
            group.Header = "January";
            group.Footer = "February";
            app.Groups
                       .InitGroupCreation()
                       .FillGroupForm(group)
                       .SubmitGroupCreation()
                       .ReturnToGroupsPage();
        }
    }
}

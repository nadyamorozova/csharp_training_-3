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
            app.Groups.Remove(1);
        }
    }
}

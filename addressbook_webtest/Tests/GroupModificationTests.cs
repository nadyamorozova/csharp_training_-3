using addressbook_webtest.Model;
using NUnit.Framework;

namespace addressbook_webtest.Test
{
    [TestFixture]
   public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificatinTests()
        {
            GroupData newData = new GroupData("Dec");
            newData.Header = "Jan";
            newData.Footer = "Feb";

            app.Groups.Modify(1, newData);
        }
   }
}

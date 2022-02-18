using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_webtest.Tests
{
    [TestFixture]
    public class AddingContactToGroupTests : ContactTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> grouplist = GroupData.GetAll();
            List<ContactData> contactlist = ContactData.GetAll();

            ContactData newcontact = new ContactData("Илон", "Маск");
            newcontact.Middlename = "Цукербергович";
            GroupData newgroup = new GroupData("Group 1");

            if (grouplist.Count == 0)
            {
                app.Groups.Create(newgroup);


                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
            }
            else
            {
                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.SequenceEqual(ContactData.GetAll()))
            {
                app.Contacts.Create(newcontact);
            }

            ContactData contact = ContactData.GetAll().Except(oldList).First();






            app.Contacts.AddContactToGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();


            Assert.AreEqual(oldList, newList);
        //    public void TestAddingContactToGroup()
        //{
        //    List<GroupData> grouplist = GroupData.GetAll();
        //    List<ContactData> contactlist = ContactData.GetAll();

        //    if (grouplist.Count != 0)
        //    {
        //        if (contactlist.Count != 0)
        //        {
        //            GroupData group = GroupData.GetAll()[0];
        //            List<ContactData> oldList = group.GetContacts();
        //            var eqv = oldList.SequenceEqual(contactlist);

        //            if (oldList.SequenceEqual(contactlist))
        //            {
        //                ContactData newcontact = new ContactData("Иван", "Сидоров");
        //                newcontact.Middlename = "Петрович";
        //                app.Contacts.Create(newcontact);

        //            }
        //            var exceptlist = contactlist.Except(oldList);
        //            ContactData contact = contactlist.Except(oldList).First();
        //            app.Contacts.AddContactToGroup(contact, group);
        //            oldList.Add(contact);
        //            List<ContactData> newList = group.GetContacts();
        //            newList.Sort();
        //            oldList.Sort();

        //            Assert.AreEqual(oldList, newList);
        //        }
        //        else
        //        {
        //            ContactData newcontact = new ContactData("Иван", "Сидоров");
        //            newcontact.Middlename = "Петрович";
        //            app.Contacts.Create(newcontact);

        //            GroupData group = GroupData.GetAll()[0];
        //            List<ContactData> oldList = group.GetContacts();
        //            ContactData contact = ContactData.GetAll().Except(oldList).First();

        //            app.Contacts.AddContactToGroup(contact, group);

        //            List<ContactData> newList = group.GetContacts();
        //            oldList.Add(contact);
        //            newList.Sort();
        //            oldList.Sort();

        //            Assert.AreEqual(oldList, newList);
        //        }
        //    }

        //    else
        //    {
        //        GroupData newgroup = new GroupData("новая группа");
        //        app.Groups.Create(newgroup);

        //        if (contactlist.Count != 0)
        //        {
        //            GroupData group = GroupData.GetAll()[0];
        //            List<ContactData> oldList = group.GetContacts();
        //            ContactData contact = ContactData.GetAll().Except(oldList).First();

        //            app.Contacts.AddContactToGroup(contact, group);

        //            List<ContactData> newList = group.GetContacts();
        //            oldList.Add(contact);
        //            newList.Sort();
        //            oldList.Sort();

        //            Assert.AreEqual(oldList, newList);
        //        }
        //        else
        //        {
        //            ContactData newcontact = new ContactData("Илон", "Маск");
        //            newcontact.Middlename = "Цукер";
        //            app.Contacts.Create(newcontact);

        //            GroupData group = GroupData.GetAll()[0];
        //            List<ContactData> oldList = group.GetContacts();
        //            ContactData contact = ContactData.GetAll().Except(oldList).First();

        //            app.Contacts.AddContactToGroup(contact, group);

        //            List<ContactData> newList = group.GetContacts();
        //            oldList.Add(contact);
        //            newList.Sort();
        //            oldList.Sort();

        //            Assert.AreEqual(oldList, newList);
                }
            }
        }
    }
}
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_webtest
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }
              
            public static IEnumerable<ContactData> ContactDataFromJsonFile()
            {
                return JsonConvert.DeserializeObject<List<ContactData>>(
                    File.ReadAllText(@"contacts.json"));
            }


        //[Test, TestCaseSource("ContactDataFromJsonFile")]
        //public void ContactCreationTest(ContactData contact)
        //{
        //    List<ContactData> oldContacts = ContactData.GetAll();

        //    app.Contacts.Create(contact);
        //    Assert.AreEqual(oldContacts.Count + 1,
        //    app.Contacts.GetContactCount());

        //    List<ContactData> newContacts = ContactData.GetAll();
        //    oldContacts.Add(contact);
        //    oldContacts.Sort();
        //    newContacts.Sort();
         
        //    Assert.AreEqual(oldContacts, newContacts);
        //}

        [Test]
        public void ContactInGroups()
        {
            foreach (GroupData group in ContactData.GetAll()[0].GetGroups())
            {
                System.Console.Out.WriteLine(group);
            }

        }

    }
}

    


//        [Test, TestCaseSource("RandomContactDataProvider")]
//        public void ContactCreationTest(ContactData contact)
//        {

//            List<ContactData> oldContacts = app.Contacts.GetContactList();

//            app.Contacts.Create(contact);

//            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

//            List<ContactData> newContacts = app.Contacts.GetContactList();
//            oldContacts.Add(contact);
//            oldContacts.Sort();
//            newContacts.Sort();
//            Assert.AreEqual(oldContacts, newContacts);
            //public void ContactCreationTest()
            //    ContactData contacts = new ContactData("J", "Lo");
            //    contacts.Address = "Arbat";
            //    contacts.MobilePhone = "777";
            //    contacts.AllEmail = "ya@ya.ru";
            //    List<ContactData> oldContacts = app.Contacts.GetContactList();


            //    app.Contacts.Create(contacts);

            //    Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            //    List<ContactData> newContacts = app.Contacts.GetContactList();
         
   
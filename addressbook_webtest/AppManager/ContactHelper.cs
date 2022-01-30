using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_webtest
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements =
            driver.FindElements(By.CssSelector("tr[name='entry']"));
            foreach (IWebElement element in elements)
            {

                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(element.Text, null));
                Console.WriteLine(element.Text);
                IList<IWebElement> lastnames =
                element.FindElements(By.CssSelector("td:nth-child(2)"));
                IList<IWebElement> firstnames =
                element.FindElements(By.CssSelector("td:nth-child(3)"));
                foreach (IWebElement lastname in lastnames)
                    foreach (IWebElement firstname in firstnames)

                    {
                        contacts.Add(new ContactData(firstname.Text, lastname.Text));
                    }

            }

            return contacts;
        }
        public ContactHelper Modify(ContactData newData)
        {

            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();

            return this;
        }

        public ContactHelper Remove(int p)
        {

            SelectContact(p);
            RemoveContact();
            //driver.SwitchTo().Alert().Accept();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SubmitContactCreation()

        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            //contactCache = null;
            return this;
        }
        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            //contactCache = null;
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            return this;
            // driver.FindElements(By.Name("entry"))
            // [index].FindElements(By.TagName("td"))[7]
            //.FindElement(By.TagName("a")).Click();
            // return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("title"), contact.Title);

            return this;
        }
    }
}



//            
//        }


//        public ContactData GetContactInformationFromTable(int index)
//        {
//            manager.Navigator.GoToHomePage();
//            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
//                 .FindElements(By.TagName("td"));
//            string lastname = cells[1].Text;
//            string firstname = cells[2].Text;
//            string address = cells[3].Text;
//            string allEmail = cells[4].Text;
//            string allPhones = cells[5].Text;

//            return new ContactData(firstname, lastname)
//            {
//                Address = address,
//                AllPhones = allPhones,
//                AllEmail = allEmail
//            };
//        }

//        //public string GetContactInformationProperties()
//        //{
//        //    manager.Navigator.GoToHomePage();
//        //    ContactDetailsProperties(0);
//        //    string AllDetails = driver.FindElement(By.XPath("//div[@id='content']")).Text;

//        //    return AllDetails;
//        //}

//        //private void ContactDetailsProperties(int v)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //private void ContactsDetailsProperties(int v)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public ContactData GetContactInformationFromEditForm(int index)
//        //{
//        //    manager.Navigator.GoToHomePage();
//        //    InitContactModification(0);

//        //    string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
//        //    string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
//        //    string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
//        //    string company = driver.FindElement(By.Name("company")).GetAttribute("value");
//        //    string title = driver.FindElement(By.Name("title")).GetAttribute("value");
//        //    string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
//        //    string address = driver.FindElement(By.Name("address")).GetAttribute("value");
//        //    string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
//        //    string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
//        //    string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
//        //    string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
//        //    string email = driver.FindElement(By.Name("email")).GetAttribute("value");
//        //    string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
//        //    string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
//        //    string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
//        //    string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
//        //    string bmonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[1]")).Text;
//        //    string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
//        //    string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
//        //    string amonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[1]")).Text;
//        //    string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
//        //    string address2 = driver.FindElement(By.Name("address2")).Text;
//        //    string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
//        //    string notes = driver.FindElement(By.Name("notes")).Text;

//        //    return new ContactData(firstname, lastname)
//        //    {
//        //        Middlename = middlename,
//        //        Nickname = nickname,
//        //        Company = company,
//        //        Title = title,
//        //        Address = address,
//        //        HomePhone = homePhone,
//        //        MobilePhone = mobilePhone,
//        //        WorkPhone = workPhone,
//        //        Fax = fax,
//        //        Email = email,
//        //        Email2 = email2,
//        //        Email3 = email3,
//        //        Homepage = homepage,
//        //        BDay = bday,
//        //        BMonth = bmonth,
//        //        BYear = byear,
//        //        ADay = aday,
//        //        AMonth = amonth,
//        //        AYear = ayear,
//        //        Address2 = address2,
//        //        Phone2 = phone2,
//        //        Notes = notes
//        //    };
//        //}

//        public ContactData GetInformationfromDetailsForm()
//        {
//            manager.Navigator.GoToHomePage();
//            OpenContactDetails(0);
//            var fullName = driver.FindElement(By.XPath("//div[@id='content']/b")).Text.Split(' ');
//            string firstname = fullName[0];
//            string middlename = fullName[1];
//            string lastname = fullName[2];
//            string allDetails = driver.FindElement(By.XPath("//div[@id='content']")).Text;

//            return new ContactData(firstname, lastname)
//            {

//                Middlename = middlename,
//                AllDetails = allDetails
//            };
//        }

//        private void OpenContactDetails(int v)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    private void OpenContactDetails(int v)
//    {
//        throw new NotImplementedException();
//    }

  

//    public int GetContactCount()
//    {
//        return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
//    }


//    private List<ContactData> contactCache = null;


//    //private object firstname;
//    //private object lastname;
//    //private string allEmail;

//    //public string Id { get; private set; }

    
//    {
//        if (contactCache == null)
//        {
//        //    contactCache = new List<ContactData>();
//        //    manager.Navigator.GoToHomePage();
//        //    ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
//        //    foreach (IWebElement element in elements)
//        //    {
//        //        IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
//        //        IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
//        //        contactCache.Add(new ContactData(firstname.Text, lastname.Text)


//        //       IWebElement lastname = cells[1];
//        //       IWebElement firstname = cells[2];

//        //        {
//        //            Id = element.FindElement(By.TagName("input")).GetAttribute("value")
//        //        });
//        //    }
//        //}

//        return new List<ContactData>(contactCache);
//    }


  

//    public ContactHelper IsContactPresent()
//    {
//        if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")))
//        {
//            ContactData contact = (new ContactData("J", "Lo"));
//            Create(contact);
//        }
//        return this;
//    }


  
    


//    public ContactHelper ContactsDetailsProperties(int index)
//    {
//        driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6]
//       .FindElement(By.TagName("a")).Click();
//        return this;
//    }


//   
//    }



  
//    }
//    public int GetNumberOfSearchResult()

//    {
//        manager.Navigator.GoToHomePage();
//        string text = driver.FindElement(By.TagName("label")).Text;
//        Match m = new Regex(@"\d+").Match(text);
//        return Int32.Parse(m.Value);
//    }
//}











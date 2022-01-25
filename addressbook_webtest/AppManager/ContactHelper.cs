using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones

            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone

            };
         }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
               
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        private List<ContactData> contactCache = null;

        public string Id { get; private set; }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                    IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    //др
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    IWebElement Lastname = cells[1];
                    IWebElement Firstname = cells[2];
                    contactCache.Add(new ContactData(firstname.Text, lastname.Text)
                    {                     
                    
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
        
            return new List<ContactData>(contactCache);
        }
            
         public ContactHelper Modify(ContactData newData)
                {
                    
                    InitContactModification(1);
                    FillContactForm(newData);
                    SubmitContactModification();
                    manager.Navigator.ReturnToHomePage();

                    return this;
                }
             
                public ContactHelper Remove(int p)
                {

                    SelectContact(p);
                    RemoveContact();
                    driver.SwitchTo().Alert().Accept();
                    return this;
                }

                public ContactHelper IsContactPresent()
                {
                    if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")))
                    {
                        ContactData contact = (new ContactData("J", "Lo"));
                        Create(contact);
                    }
                    return this;
                }

                public ContactHelper InitNewContactCreation()
                {
                    driver.FindElement(By.LinkText("add new")).Click();
                    return this;
                }
                public ContactHelper FillContactForm(ContactData contact)
                {
                    Type(By.Name("firstname"), contact.Firstname);
                    Type(By.Name("lastname"), contact.Lastname);
                    Type(By.Name("address"), contact.Address);
                    Type(By.Name("mobile"), contact.MobilePhone);
                    Type(By.Name("email"), contact.AllEmail);
                    return this;
                }

                public ContactHelper SubmitContactCreation()
                {
                    driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
                    contactCache = null;
                    return this;
                }

                public ContactHelper InitContactModification(int v)
                {
                 driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();

            //driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
                  return this;
                }

                public ContactHelper SubmitContactModification()
                {
                    driver.FindElement(By.Name("update")).Click();
                    contactCache = null;
                    return this;
                }
                public ContactHelper SelectContact(int index)
                {
               driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index  + "]")).Click();
                 return this;
                }

                public ContactHelper RemoveContact()
                {
                 driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                 driver.SwitchTo().Alert().Accept();
                 contactCache = null;
                 return this;
                 }

                 public int GetNumberOfSearchResult()

                {
                manager.Navigator.GoToHomePage();
                string text = driver.FindElement(By.TagName("label")).Text;
                Match m = new Regex(@"\d+").Match(text);
                return Int32.Parse(m.Value);
                }
            } 
        } 
    



            //        List<ContactData> contacts = new List<ContactData>();
            //manager.Navigator.GoToHomePage();
            //ICollection<IWebElement> elements =
            //driver.FindElements(By.CssSelector("tr[name='entry']"));
            //foreach (IWebElement element in elements)
            //{
                
            //    contacts.Add(new ContactData(element.Text, null));
            //    Console.WriteLine(element.Text);

            //    IList<IWebElement> lastnames =
            //    element.FindElements(By.CssSelector("td:nth-child(2)"));
            //    IList<IWebElement> firstnames =
            //    element.FindElements(By.CssSelector("td:nth-child(3)"));
            //    foreach (IWebElement lastname in lastnames) 
            //    foreach (IWebElement firstname in firstnames)
                    
            //    {
            //    contacts.Add(new ContactData(firstname.Text, lastname.Text));
            //    }
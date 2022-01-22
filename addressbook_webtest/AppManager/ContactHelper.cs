using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

       
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        private List<ContactData> contactCache = null;

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
            //if (contactCache == null)
            //{
            //    contactCache = new List<ContactData>();
            //    manager.Navigator.GoToHomePage();
            //    ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
            //    foreach (IWebElement element in elements)
            //    {
            //        IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
            //        IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));

            //        contactCache.Add(new ContactData(firstname.Text, lastname.Text));
                    
            //            //Id = element.FindElement(By.TagName("input")).GetAttribute("value"));
                
            

                           public ContactHelper Modify(int p, ContactData newData)
                {
                    InitContactModification(p);
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
                    return this;
                }

                public ContactHelper SubmitContactCreation()
                {
                    driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
                    contactCache = null;
                    return this;
                }

                public ContactHelper InitContactModification(int index)
                {
                    driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
                    return this;
                }
                public ContactHelper SubmitContactModification()
                {
                    driver.FindElement(By.Name("update")).Click();
                    return this;
                }
                public ContactHelper SelectContact(int index)
                {
                    driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
                    return this;
                }

                public ContactHelper RemoveContact()
                {
                    driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                    return this;
                }
            } 
        } 
    




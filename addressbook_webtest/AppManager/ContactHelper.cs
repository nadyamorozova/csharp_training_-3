﻿using System;
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
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {

            IsContactPresent();
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
                contact.Middlename = "Sergeevna";

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
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            return this;
        }

        private void SelectContact(int p)
        {
            throw new NotImplementedException();
        }

        private void InitContactModification(int p)
        {
            throw new NotImplementedException();
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




       
        





            public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
     
        public ContactHelper ReturnToAddNewPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
    }
}
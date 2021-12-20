﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contactData)
        {
            GoToAddNewPage();
            FillContactForm(contactData);
            SubmitContactCreation();
            ReturnToAddNewPage();
            return this;
        }
        public ContactHelper Modify(ContactData newData)
        {

            GoToAddNewPage();
            FillContactForm(newData);
            SubmitContactCreation();
            ReturnToAddNewPage();
            return this;
        }
        public ContactHelper Remove(int v)
        {
            GoToAddNewPage();
            SelectContcats(v);
            RemoveContact();
            return this;
        }
        public ContactHelper SelectContcats(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper ReturnToAddNewPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData group)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(group.FirstName);

            driver.FindElement(By.Name("mobile")).SendKeys(group.Mobile);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(group.Email);
            return this;
        }
    }

    public class ContactData
    {
        internal static string Address;
        internal string FirstName;
        internal string Mobile;
        internal string Email;
        private string v;

        public ContactData(string v)
        {
            this.v = v;
        }

        public static object LastName { get; internal set; }

        public static implicit operator ContactData(string v)
        {
            throw new NotImplementedException();
        }
    }
}
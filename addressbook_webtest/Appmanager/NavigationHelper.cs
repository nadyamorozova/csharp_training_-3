﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_webtest.AppManager
{
   public class NavigationHelper : HelperBase
    {
       
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/index.php");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}

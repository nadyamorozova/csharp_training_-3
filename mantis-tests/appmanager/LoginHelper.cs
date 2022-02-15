﻿using System;
using OpenQA.Selenium;


namespace mantis_tests
{
   public  class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.ClassName("user-info")).Click();
                driver.FindElement(By.CssSelector("#navbar-container > div.navbar-buttons.navbar-header.navbar-collapse.collapse > ul > li.grey.open > ul > li:nth-child(4) > a")).Click();
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//span[@class = 'user-info']"));
            throw new NotImplementedException();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        private string GetLoggedUserName()
        {
            return driver.FindElement(By.XPath("//span[@class = 'user-info']")).Text;
        }
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {
        private addressbook_webtest.AppManager.ApplicationManager applicationManager;

        public LoginHelper(addressbook_webtest.AppManager.ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }
    }

    public class HelperBase
    {
    }

    public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {

            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

        }
    }
}





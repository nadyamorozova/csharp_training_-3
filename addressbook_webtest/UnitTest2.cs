using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
            driver.FindElement(By.Name("searchstring")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Е");
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys("Е");
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Е");
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys("Е");
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("Е");
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("Е");
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys("Е");
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys("Е");
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys("Е");
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys("Е");
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("Е");
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("17");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("December");
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1983");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("19");
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("December");
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("1982");
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys("Группа");
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys("крови");
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys("на рукаве");
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
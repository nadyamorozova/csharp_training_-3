﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;

       public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
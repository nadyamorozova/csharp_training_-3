﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData ("admin", "secret"));
            InitContactCreation();
            FillContactForm(new Contact("Nadya", "Morozova"));
            SubmitContactCreation();
            ReturnToGroupsPage();
         }
      }
    }


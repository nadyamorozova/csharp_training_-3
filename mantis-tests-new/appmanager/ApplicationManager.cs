using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public LoginHelper Login { get; set; }
        public ManagementMenuHelper MenuManager { get; set; }
        public ProjectManagementHelper Project { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/mantisbt-2.25.2";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            //James = new JamesHelper(this);
            Login = new LoginHelper(this);
            MenuManager = new ManagementMenuHelper(this);
            Project = new ProjectManagementHelper(this);
            API = new APIHelper(this);
            Admin = new AdminHelper(this, baseURL);
        }
        ~ApplicationManager()
        {
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    
                }
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + @"/login_page.php";
                app.Value = newInstance;
            }

            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }

    }
}
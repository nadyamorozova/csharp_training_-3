using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Mantis = mantis_tests_new.Mantis;
namespace mantis_tests
{

    [TestFixture]
    public class ApiProjectTests : AuthBase
    {

        [Test]

        public void TestProjectCreationAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };
            var oldProjects = app.API.GetProjectsList(account);
            app.API.CreateNewProject(account, project);
            var newProjects = app.API.GetProjectsList(account);
            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void TestProjectRemovalAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            int projectsCount = app.API.GetProjectsList(account).Count;


            if (projectsCount == 0)
            {
                app.API.CreateNewProject(account, project);
            }


            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Remove();

            //Thread.Sleep(5000);

            //List<ProjectData> newProjects = app.Project.GetProjectList();

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());
        }
        [Test]
        public void TestProjectRemoval()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };
            ProjectData project = new ProjectData()
            {
                Name = "Project" + " " + DateTime.Now,
                Description = "Test",
            };
            app.Login.Login(account);

            app.MenuManager.OpenMenuProject();
        }

        //    [Test]

        //public void GetListAPI()
        //{
        //    AccountData account = new AccountData()
        //    {

        //        Name = "administrator",
        //        Password = "root",

        //    };

        // var projects = app.API.GetProjectsList(account);

            
        //}

        [Test]

        public void GetList()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.Login.Logout();
            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();
            app.Project.GetProjectList();
            app.Project.GetProjectCount();


        }
    }
}

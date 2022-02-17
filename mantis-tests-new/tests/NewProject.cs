﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class NewProject : AuthBase
    {



        [Test]
        public void TestProjectCreation()
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

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Create(project);

            int i = app.Project.GetProjectCount();

            Assert.AreEqual(oldProjects.Count+1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetProjectList();
            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
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


            if (app.Project.GetProjectCount() == 0)
            {
                app.Project.Create(project);
            }
            List<ProjectData> oldProjects = app.Project.GetProjectList();


            app.Project.Remove();

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());
            app.Login.Logout();

        }


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
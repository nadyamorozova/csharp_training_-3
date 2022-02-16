//using System;
//using System.Collections.Generic;
//using NUnit.Framework;

//namespace mantis_tests
//{
//    [TestFixture]
//    public class ProjectTests : TestBase
//    {
//        AccountData account = new AccountData()
//        {
//            Name = "administrator",
//            Password = "root",

//        };

//        ProjectData project = new ProjectData
//        {
//            ProjectName = "project_" + DateTime.Now.ToString(),
//            Description = "Description"
//        };



//        [Test]
//        public void ProjectCreationTest()
//        {
//            app.Auth.Login(account);
//            app.Navigator.GoToProjectsPage();

//            List<ProjectData> oldProjects = app.Projects.GetProjectList();
//            app.Projects.Create(project);

//            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectList().Count);

//            List<ProjectData> newProjects = app.Projects.GetProjectList();
//            oldProjects.Add(project);
//            oldProjects.Sort();
//            newProjects.Sort();
//            Assert.AreEqual(oldProjects, newProjects);

//        }

//        [Test]
//        public void ProjectRemovalTest()
//        {

//            app.Auth.Login(account);
//            app.Navigator.GoToProjectsPage();

//            List<ProjectData> projectsList = app.Projects.GetProjectList();
//            if (projectsList.Count == 0)
//            {
//                app.Projects.Create(project);
//            }

//            List<ProjectData> oldProjects = app.Projects.GetProjectList();

//            app.Projects.Remove(1);

//            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectList().Count);

//            List<ProjectData> newProjects = app.Projects.GetProjectList();
//            oldProjects.Remove(project);
//            oldProjects.Sort();
//            newProjects.Sort();
//            Assert.AreEqual(oldProjects, newProjects);

//        }


//    }
//}

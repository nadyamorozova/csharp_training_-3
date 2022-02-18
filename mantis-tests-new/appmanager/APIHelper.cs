using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using Mantis = mantis_tests_new.Mantis;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }


        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {

            mantis_tests_new.Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            mantis_tests_new.Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);

        }



        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            mantis_tests_new.Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            mantis_tests_new.Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;

            client.mc_project_add(account.Name, account.Password, project);

        }
          public mantis_tests_new.Mantis.ProjectData[] GetProjectsList(AccountData account)
        {
           Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

           Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            return projects;

        }
    }
}



        //
        //{
        //    Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

//    Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

//    //foreach (Mantis.ProjectData project in projects)
//    //      Console.Out.WriteLine(project.name);

//    return projects;
//List<ProjectData> projectList = new List<ProjectData>();
//public List<ProjectData> GetProjectsList(AccountData account)
//{
//    Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
//    Mantis.ProjectData[] projectData = client.mc_projects_get_user_accessible(account.Name, account.Password);
//    foreach (var project in projectData)
//    {
//        projectList.Add(new ProjectData
//        {
//            Id = project.id,
//            Description = project.description,
//            ProjectName = project.name
//        });
//    }
//    return projectList;
//}


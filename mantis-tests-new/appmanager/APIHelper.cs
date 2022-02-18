using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }


        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
           mantis_tests_new.Mantis.MantisConnectPortTypeClient client = new mantis_tests_new.Mantis.MantisConnectPortTypeClient();
            mantis_tests_new.Mantis.IssueData issue = new mantis_tests_new.Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantis_tests_new.Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);

        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            mantis_tests_new.Mantis.MantisConnectPortTypeClient client = new mantis_tests_new.Mantis.MantisConnectPortTypeClient();
            mantis_tests_new.Mantis.ProjectData project = new mantis_tests_new.Mantis.ProjectData();
            project.name = projectData.Name;

            client.mc_project_add(account.Name, account.Password, project);

        }



        public mantis_tests_new.Mantis.ProjectData[] GetProjectsList(AccountData account)
        {
            mantis_tests_new.Mantis.MantisConnectPortTypeClient client = new mantis_tests_new.Mantis.MantisConnectPortTypeClient();

            mantis_tests_new.Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            //foreach (Mantis.ProjectData project in projects)
            //      Console.Out.WriteLine(project.name);

            return projects;

        }
    }
}
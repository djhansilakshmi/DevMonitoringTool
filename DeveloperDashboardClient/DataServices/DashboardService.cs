using DeveloperDashboardClient.Dtos;
using Octokit;
using System.Collections.Generic;
using System.Text.Json;

namespace DeveloperDashboardClient.DataServices
{
    public class DashboardService : IDashboardService
    {
        private readonly string _owner;
        private readonly IGitHubClient _githubClient;

        public DashboardService(string owner,IGitHubClient githubClient)
        {
            this._owner = owner;
            this._githubClient = githubClient;
        }
        public List<DashboardVM> FilterByProjects(string Project)
        {
            throw new NotImplementedException();
        }

        public List<DashboardVM> FilterByTeams(string Team)
        {
            throw new NotImplementedException();
        }

        public List<DashboardVM> FilterByTeamsNProjects(string Teams, string Project)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DashboardVM>> GetAllProjectsFromAllTeams()
        {
            var resp= await _githubClient.Repository.GetAllForUser(this._owner);

            var result=resp.ToList();

            List<DashboardVM> dashboardVMs = new();

            foreach (var repo in result)
            {
                DashboardVM dashboardVM = new DashboardVM();

                var pullRequests = await _githubClient.PullRequest.GetAllForRepository(_owner, repo.Name);
                var pullRequestCount = pullRequests.Count;


                var deployments = await _githubClient.Repository.Deployment.GetAll(_owner, repo.Name);
                var lastDeployment = deployments.OrderByDescending(d => d.CreatedAt).FirstOrDefault();


                var apiUrl = $"repos/{_owner}/{repo.Name}/actions/workflows";

                var parameters = new Dictionary<string, string>();

               //var workflows = await _githubClient.Connection.Get<List<Workflow>>(new Uri(apiUrl, UriKind.Relative), parameters);




                //foreach (Workflow workflow in workflows)
                //{
                //    long workflowId = workflow.Id;
                //    // Do something with the workflowId
                //    Console.WriteLine(workflowId);
                //}


                //var workflows = JsonSerializer.Deserialize<List<Workflow>>(response.HttpResponse.Body.ToString());


               // var runs = await _githubClient.Actions.Workflows.Get(_owner, repo.Name, workflows[0].Id);




                dashboardVM.Project = repo.Name;
                dashboardVM.BranchName = repo.DefaultBranch;
                dashboardVM.TotalPR = pullRequestCount;

                dashboardVMs.Add(dashboardVM);
            }

            return dashboardVMs;

        }
    }
}

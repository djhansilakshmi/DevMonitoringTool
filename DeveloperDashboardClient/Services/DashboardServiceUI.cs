
using DashboardLib.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeveloperDashboardClient.Services
{
    public class DashboardServiceUI : IDashboardServiceUI
    {
        private readonly string _owner;
        private readonly HttpClient _httpClient;

        public DashboardServiceUI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Repositories>> FilterByProjects(string repoName)
        {

            //var responseContent = string.Empty;
            //string url = $"/api/Dashboard/GetRepo/{repoName}";

            //var request = new HttpRequestMessage(HttpMethod.Get, url);
            //var response = await _httpClient.SendAsync(request);

            //if (response.IsSuccessStatusCode)
            //{
            //    responseContent = await response.Content.ReadAsStringAsync();
            //}

            //var repositories = JsonConvert.DeserializeObject<List<Repositories>>(responseContent);
            //return repositories;
            return null;

        }

        public List<DashboardVM> FilterByTeams(string Team)
        {
            throw new NotImplementedException();
        }

        public List<DashboardVM> FilterByTeamsNProjects(string Teams, string Project)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Repositories>> GetMasterProjectsFromAllTeams()
        {

            var responseContent = string.Empty;
            string url = $"/api/Dashboard/alldata";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            var repositories = JsonConvert.DeserializeObject<List<Repositories>>(responseContent);
            return repositories;

        }

        //private async Task<List<Repositories>> GetAllRepositoriesDetails(List<Repositories> repos)
        //{
        //    for (int r = 0; r < repos.Count; r++)
        //    {
        //        var repoName = repos[r].Name;
        //        var branchDetails = await GetBranchDetails(repoName, "master");
        //        var branches = new List<Branch>();

        //        if (branchDetails is not null)
        //        {
        //            var pullDetails = await GetPullRequest(repoName);
        //            var buildDetails = await GetBuilds(repoName);
        //            var deploymentDetails = await GetDeployment(repoName);

        //            if (pullDetails is not null && pullDetails.Count > 0)
        //            {
        //                List<PullRequest> pullRequests = new List<PullRequest>();
        //                pullRequests.AddRange((pullDetails.Where(y => y.head.BranchName.Equals(branchDetails.Name)).ToList()));

        //                branchDetails.PullRequests = pullRequests;
        //            }

        //            if (buildDetails.ActionWorkflowRuns.Count > 0)
        //            {

        //                Actions actions = new Actions { ActionWorkflowRuns = new List<ActionWorkflowRun>() };
        //                actions.ActionWorkflowRuns.AddRange(buildDetails.ActionWorkflowRuns.Where(y => y.BranchName.Equals(branchDetails.Name)));

        //                branchDetails.Actions = actions;

        //            }

        //            if (deploymentDetails.Count > 0)
        //            {
        //                List<Deployment> deployments = new List<Deployment>();
        //                deployments.AddRange(deploymentDetails.Where(y => y.BranchName.Equals(branchDetails.Name)).ToList());

        //                branchDetails.Deployments = deployments;

        //            }
        //        }


        //        if (branchDetails is not null)
        //            branches.Add(branchDetails);

        //        repos[r] = new Repositories() { Branches = branches, Name = repoName };

        //    }

        //    return repos;
        //}

        public async Task<List<Repositories>> GetAllRepos()
        {
            return null;
           // return await _repoService.GetAll();
        }

        public async Task<Repositories> GetRepo(string owner, string repoName)
        {
            return null;
           // return await _repoService.GetRepo(owner, repoName);
        }

        public async Task<List<Repositories>> GetAllProjectsFromAllTeams()
        {
            return null;
            //var repos = await _repoService.GetAll();

            //for (int r = 0; r < repos.Count; r++)
            //{
            //    var repoName = repos[r].Name;
            //    var branchDetails = await GetBranchDetails(repoName);
            //    var branches = new List<Branch>();

            //    if (branchDetails is not null)
            //    {
            //        var pullDetails = await GetPullRequest(repoName);
            //        var buildDetails = await GetBuilds(repoName);
            //        var deploymentDetails = await GetDeployment(repoName);

            //        for (int i = 0; i < branchDetails.Count; i++)
            //        {
            //            if (pullDetails is not null && pullDetails.Count > 0)
            //            {
            //                List<PullRequest> pullRequests = new List<PullRequest>();
            //                pullRequests.AddRange((pullDetails.Where(y => y.head.BranchName.Equals(branchDetails[i].Name)).ToList()));

            //                branchDetails[i].PullRequests = pullRequests;
            //            }

            //            if (buildDetails.ActionWorkflowRuns.Count > 0)
            //            {

            //                Actions actions = new Actions { ActionWorkflowRuns = new List<ActionWorkflowRun>() };
            //                actions.ActionWorkflowRuns.AddRange(buildDetails.ActionWorkflowRuns.Where(y => y.BranchName.Equals(branchDetails[i].Name)));

            //                branchDetails[i].Actions = actions;

            //            }

            //            if (deploymentDetails.Count > 0)
            //            {
            //                List<Deployment> deployments = new List<Deployment>();
            //                deployments.AddRange(deploymentDetails.Where(y => y.BranchName.Equals(branchDetails[i].Name)).ToList());

            //                branchDetails[i].Deployments = deployments;

            //            }
            //        }
            //    }


            //    if (branchDetails is not null)
            //        branches.AddRange(branchDetails);

            //    repos[r] = new Repositories() { Branches = branches, Name = repoName };

            //}

            //return repos;

        }

        //async Task<List<Branch>> GetBranchDetails(string repository)
        //{
        //    return await _branchService.GetAll(_owner, repository).ConfigureAwait(false);

        //}
        //async Task<Branch> GetBranchDetails(string repository, string branchName)
        //{
        //    return await _branchService.Get(_owner, repository, branchName).ConfigureAwait(false);

        //}

        //async Task<List<PullRequest>> GetPullRequest(string repository)
        //{

        //    return await _pullService.Get(_owner, repository).ConfigureAwait(false);

        //}

        //async Task<Actions> GetBuilds(string repository)
        //{
        //    return await _buildService.Get(_owner, repository).ConfigureAwait(false);

        //}

        //async Task<List<Deployment>> GetDeployment(string repository)
        //{
        //    return await _deploymentService.Get(_owner, repository);
        //}


    }


}

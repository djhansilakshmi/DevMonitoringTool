using DashboardLib.Dtos;
using DashboardLib.Dtos;
using DeveloperDashboardAPI.DataServices.GitServices;
using DeveloperDashboardAPI.DataServices.DeepSourceServices;
using DeveloperDashboardAPI.DataServices.GitServices;

namespace DeveloperDashboardAPI.Services.DataServices
{
    public class DashboardService : IDashboardService
    {
        private readonly string _owner;
        private readonly string _DeepSourceowner;
        private readonly IBranchService _branchService;
        private readonly IBuildService _buildService;
        private readonly IDeploymentService _deploymentService;
        private readonly ICommitService _commitService;
        private readonly IPullService _pullService;
        private readonly IRepoService _repoService;
        private readonly ICodeCoverage _codeCoverage;

        public DashboardService(string owner, 
                                string DeepSourceowner,
                                IBranchService branchService,
                                IBuildService buildService,
                                IDeploymentService deploymentService,
                                ICommitService commitService,
                                IPullService pullService,
                                IRepoService repoService,
                                ICodeCoverage codeCoverage)
        {
            _owner = owner;
            _DeepSourceowner = DeepSourceowner;
            _branchService = branchService;
            _buildService = buildService;
            _deploymentService = deploymentService;
            _commitService = commitService;
            _pullService = pullService;
            _repoService = repoService;
            _codeCoverage = codeCoverage;
        }
        public async Task<List<Repositories>> FilterByProjects(string repoName)
        {
            var repo = await GetRepo(_owner, repoName);

            var repos = new List<Repositories>();
            repos.Add(repo);
            var repoDetails = await GetAllRepositoriesDetails(repos);

            return repoDetails;
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
            List<Repositories> repos = await GetAllRepos();

            var repositories = await GetAllRepositoriesDetails(repos);

            return repositories;
        }

        private async Task<List<Repositories>> GetAllRepositoriesDetails(List<Repositories> repos)
        {
            for (int r = 0; r < repos.Count; r++)
            {
                var repoName = repos[r].Name;
                var branchDetails = await GetBranchDetails(repoName, "master");
                var branches = new List<Branch>();

                if (branchDetails is not null)
                {

                    Task[] tasks = new Task[4]
                    {

                        Task.Run( () => GetPullRequest(repoName)),
                        Task.Run( () => GetBuilds(repoName)),
                        Task.Run( () => GetDeployment(repoName)),
                        Task.Run( () => GetCoverage(repoName)),
                    };

                    Task.WaitAll(tasks);

                    var pullDetails = ((Task<List<PullRequest>>)tasks[0]).Result;
                    var buildDetails = ((Task<Actions>)tasks[1]).Result;
                    var deploymentDetails = ((Task<List<Deployment>>)tasks[2]).Result;
                    var linecoverage = ((Task<CodeCoverage>)tasks[3]).Result;

                    //var pullDetails = await GetPullRequest(repoName);
                    //var buildDetails = await GetBuilds(repoName);
                    //var deploymentDetails = await GetDeployment(repoName);
                    //var linecoverage = await GetCoverage(repoName);

                    if (pullDetails is not null && pullDetails.Count > 0)
                    {
                        List<PullRequest> pullRequests = new List<PullRequest>();
                        pullRequests.AddRange((pullDetails.Where(y => y.Head.BranchName.Equals(branchDetails.Name)).ToList()));

                        branchDetails.PullRequests = pullRequests;
                    }

                    if (buildDetails.ActionWorkflowRuns.Count > 0)
                    {
                        Actions actions = new Actions { ActionWorkflowRuns = new List<ActionWorkflowRun>() };
                        actions.ActionWorkflowRuns.AddRange(buildDetails.ActionWorkflowRuns.Where(y => y.BranchName.Equals(branchDetails.Name)));

                        branchDetails.Actions = actions;
                    }

                    if (deploymentDetails.Count > 0)
                    {
                        List<Deployment> deployments = new List<Deployment>();
                        deployments.AddRange(deploymentDetails.Where(y => y.BranchName.Equals(branchDetails.Name)).ToList());

                        branchDetails.Deployments = deployments;
                    }

                    if (linecoverage.Data.Repository.Metrics.Count > 0)
                    {
                        //List<Metric> metric = new List<Metric>();
                        //metric = linecoverage.data.repository.metrics;
                        CodeCoverage codeCoverage = new CodeCoverage();

                        //codeCoverage.(deploymentDetails.Where(y => y.BranchName.Equals(branchDetails[i].Name)).ToList());
                        //double lncoverage = branchDetails[i].CodeCoverage.data.repository.metrics[0].items[0].values.edges[0].node.value;
                        branchDetails.CodeCoverage = linecoverage;
                    }

                    branches.Add(branchDetails);
                    repos[r] = new Repositories() { Branches = branches, Name = repoName };
                }

            }

            return repos.SkipWhile(x => x.Branches is null).ToList();
        }

        public async Task<List<Repositories>> GetAllRepos()
        {
            return await _repoService.GetAll();
        }

        public async Task<Repositories> GetRepo(string owner, string repoName)
        {
            return await _repoService.GetRepo(owner, repoName);
        }

        public async Task<List<Repositories>> GetAllProjectsFromAllTeams()
        {
            var repos = await _repoService.GetAll();

            for (int r = 0; r < repos.Count; r++)
            {
                var repoName = repos[r].Name;
                var branchDetails = await GetBranchDetails(repoName);
                var branches = new List<Branch>();

                if (branchDetails is not null)
                {
                    var pullDetails = await GetPullRequest(repoName);
                    var buildDetails = await GetBuilds(repoName);
                    var deploymentDetails = await GetDeployment(repoName);

                    for (int i = 0; i < branchDetails.Count; i++)
                    {
                        if (pullDetails is not null && pullDetails.Count > 0)
                        {
                            List<PullRequest> pullRequests = new List<PullRequest>();
                            pullRequests.AddRange((pullDetails.Where(y => y.Head.BranchName.Equals(branchDetails[i].Name)).ToList()));

                            branchDetails[i].PullRequests = pullRequests;
                        }

                        if (buildDetails.ActionWorkflowRuns.Count > 0)
                        {

                            Actions actions = new Actions { ActionWorkflowRuns = new List<ActionWorkflowRun>() };
                            actions.ActionWorkflowRuns.AddRange(buildDetails.ActionWorkflowRuns.Where(y => y.BranchName.Equals(branchDetails[i].Name)));

                            branchDetails[i].Actions = actions;
                        }

                        if (deploymentDetails.Count > 0)
                        {
                            List<Deployment> deployments = new List<Deployment>();
                            deployments.AddRange(deploymentDetails.Where(y => y.BranchName.Equals(branchDetails[i].Name)).ToList());

                            branchDetails[i].Deployments = deployments;
                        }
                    }
                }

                if (branchDetails is not null)
                    branches.AddRange(branchDetails);

                repos[r] = new Repositories() { Branches = branches, Name = repoName };
            }

            return repos;
        }

        async Task<List<Branch>> GetBranchDetails(string repository)
        {
            return await _branchService.GetAll(_owner, repository).ConfigureAwait(false);
        }
        async Task<Branch> GetBranchDetails(string repository, string branchName)
        {
            return await _branchService.Get(_owner, repository, branchName).ConfigureAwait(false);
        }

        async Task<List<PullRequest>> GetPullRequest(string repository)
        {
            return await _pullService.Get(_owner, repository).ConfigureAwait(false);
        }

        async Task<Actions> GetBuilds(string repository)
        {
            return await _buildService.Get(_owner, repository).ConfigureAwait(false);
        }

        async Task<List<Deployment>> GetDeployment(string repository)
        {
            return await _deploymentService.Get(_owner, repository);
        }

        async Task<CodeCoverage> GetCoverage(string repository)
        {
            return await _codeCoverage.Get(_DeepSourceowner, repository);
        }
    }
}

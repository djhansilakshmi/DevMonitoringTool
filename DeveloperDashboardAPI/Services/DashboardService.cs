using DeveloperDashboardAPI.Dtos;
using DeveloperDashboardClient.Services.GitServices;

namespace DeveloperDashboardAPI.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly string _owner;
        private readonly IBranchService _branchService;
        private readonly IBuildService _buildService;
        // private readonly ICommitService _ccmmitService;
        private readonly IDeploymentService _deploymentService;
        private readonly ICommitService _commitService;
        private readonly IPullService _pullService;
        private readonly IRepoService _repoService;


        public DashboardService(string owner,
                                IBranchService branchService,
                                IBuildService buildService,
                                // ICommitService CcmmitService,
                                IDeploymentService deploymentService,
                                ICommitService commitService,
                                IPullService pullService,
                                IRepoService repoService)
        {
            _owner = owner;
            _branchService = branchService;
            _buildService = buildService;
            _deploymentService = deploymentService;
            _commitService = commitService;
            _pullService = pullService;
            _repoService = repoService;
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
                            pullRequests.AddRange((pullDetails.Where(y => y.head.BranchName.Equals(branchDetails[i].Name)).ToList()));

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
                {
                    branches.AddRange(branchDetails);
                }

                repos[r] = new Repositories() { Branches = branches, Name = repoName };
            }

            return repos;
        }

        async Task<List<Branch>> GetBranchDetails(string repository)
        {
            return await _branchService.GetAll(_owner, repository).ConfigureAwait(false);

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
    }
}

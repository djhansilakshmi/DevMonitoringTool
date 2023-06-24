
// See https://aka.ms/new-console-template for more information
using DeveloperDashboardClient.Client;
using DeveloperDashboardClient.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

Console.WriteLine("Hello, World!");


//var owner = "djhansilakshmi";


var owner = "rganesanAltimetrik";



//var repo = "sampledataapi";
//var repo = "DevMonitoringTool";

//var depoloyments = new DeploymentService();
//depoloyments.Get(owner, repo);

//var runs = new BuildService();
//runs.Get(owner, repo);


//var pullService1 = new PullService();
//pullService1.Get(owner, repo);


//var depoloyments = new Deployments();
//depoloyments.Get(owner, repo);


//var runs = new BuildService();
//runs.Get(owner, repo);


//var repoService = new RepoService();
//var repos = repoService.GetAll();


//var repositories = new List<Repositories>();

////var pulls = new List<PullRequest>();
////var builds = new Build();
////var deployments = new List<Deployment>();


//foreach (var repository in repos)
//{
//    var branchDetails = GetBranchDetails(repository.Name);
//    var branches = new List<Branch>();

//    if (branchDetails is not null)
//    {
//        for (int i = 0; i < branchDetails.Count; i++)
//        {
//            var pullDetails = GetPullRequest(repository.Name);
//            if (pullDetails is not null && pullDetails.Count > 0)
//            {
//                List<PullRequest> pullRequests = new List<PullRequest>();
//                pullRequests.AddRange((pullDetails.Where(y => y.head.BranchName.Equals(branchDetails[i].Name)).ToList()));

//                branchDetails[i].PullRequests = pullRequests;
//            }

//            var buildDetails = GetBuilds(repository.Name);
//            if (buildDetails is not null && buildDetails.ActionWorkflowRuns.Count > 0)
//            {

//                Actions actions = new Actions { ActionWorkflowRuns = new List<ActionWorkflowRun>() };
//                actions.ActionWorkflowRuns.AddRange(buildDetails.ActionWorkflowRuns.Where(y => y.BranchName.Equals(branchDetails[i].Name)));

//                branchDetails[i].Actions = actions;

//            }

//            var deploymentDetails = GetDeployment(repository.Name);
//            if (deploymentDetails is not null && deploymentDetails.Count > 0)
//            {
//                List<Deployment> deployments = new List<Deployment>();
//                deployments.AddRange(deploymentDetails.Where(y => y.BranchName.Equals(branchDetails[i].Name)).ToList());

//                branchDetails[i].Deployments = deployments;

//            }
//        }
//    }



//    if (branchDetails is not null)
//        branches.AddRange(branchDetails);

//    repositories.Add(new Repositories() { Branches = branches, Name = repository.Name });

//}

//Console.WriteLine(JsonConvert.SerializeObject(repositories));
//Console.WriteLine(  );

//List<Branch> GetBranchDetails(string repository)
//{
//    var brancheService = new BranchService(new GitCalls(new HttpClient()));
//    return brancheService.GetAll(owner, repository);

//}

//List<PullRequest> GetPullRequest(string repository)
//{
//    var pullService = new PullService();
//    return pullService.Get(owner, repository);

//}

//Actions GetBuilds(string repository)
//{
//    var runs = new BuildService();
//    return runs.Get(owner, repository);

//}

//List<Deployment> GetDeployment(string repository)
//{
//    var depoloyments = new DeploymentService();
//    return depoloyments.Get(owner, repository);
//}


















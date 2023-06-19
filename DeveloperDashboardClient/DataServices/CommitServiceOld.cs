using static DeveloperDashboardClient.DataServices.CommitServiceOld;

namespace DeveloperDashboardClient.DataServices
{

    public class CommitServiceOld : ICommitServiceOld
    {
        //private readonly string _owner;
        //private readonly string _repo;


        //public CommitServiceOld(string owner, string repo)
        //{
        //    this._owner = owner;
        //    this._repo = repo;
        //}
        //public Task<IReadOnlyList<GitHubCommit>> GetAllCommits(GitHubClient client)
        //{

        //    var commits = client.Repository.Commit.GetAll(_owner, _repo);

        //    IReadOnlyList<Branch> branches = client.Repository.Branch.GetAll(_owner, _repo).GetAwaiter().GetResult();

        //    // Console.WriteLine($"Repository.Branch.Get: Name={branch.Name}");

        //        StaleBranches(branches, client);

        //    return commits;

        //}

        //    private void StaleBranches(IReadOnlyList<Branch> branches, GitHubClient client)
        //    {

        //    var staleBranches = new List<Branch>();

        //    foreach (var branch in branches)
        //    {

        //        var branchlastcommit = client.Repository.Commit.Get(_owner, _repo, branch.Commit.Sha).GetAwaiter().GetResult();
        //        var branchlastdatetime = branchlastcommit.Commit.Committer.Date;

        //        TimeSpan timeSinceUpdate = DateTime.Now - branchlastdatetime;

        //        TimeSpan threshold = TimeSpan.FromDays(30);

        //        if (timeSinceUpdate > threshold)
        //        {
        //            staleBranches.Add(branch);
        //        }
        //    }
        //}



        //public async Task RepositoryExamples(GitHubClient client)
        //{

        //    var owner = "djhansilakshmi";
        //    var repo = "DevMonitoringTool";

        //    Repository repository = await client.Repository.Get("octokit", "octokit.net");
        //    Console.WriteLine($"Repository.Get: Id={repository.Id}");


        //    Repository repositoryJhansi = await client.Repository.Get(owner, repo);
        //    Console.WriteLine($"Repository.Get: Id={repository.Id}");

        //    var commits = await client.Repository.Commit.GetAll(owner, repo);


        //    Branch branch = await client.Repository.Branch.Get("octokit", "octokit.net", "master");
        //    Console.WriteLine($"Repository.Branch.Get: Name={branch.Name}");

        //    SearchRepositoryResult result = await client.Search.SearchRepo(
        //        new SearchRepositoriesRequest("octokit")
        //        {
        //            In = new InQualifier[] { InQualifier.Name }
        //        });
        //    Console.WriteLine($"Search.SearchRepo (Simple Search): TotalCount={result.TotalCount}");

        //    await RepositoryAllFieldsExample(client);
        //}

        //private static async Task RepositoryAllFieldsExample(GitHubClient client)
        //{
        //    var fromDate = new DateTime(2012, 3, 17);
        //    var toDate = new DateTime(2019, 3, 17);

        //    int fromNumber = 1;
        //    int toNumber = 10000;

        //    string term = "octokit";
        //    string user = "octokit";

        //    var request = new SearchRepositoriesRequest(term)
        //    {
        //        Archived = false,
        //        Created = new DateRange(fromDate, toDate),
        //        Fork = ForkQualifier.IncludeForks,
        //        Forks = new Octokit.Range(fromNumber, toNumber),
        //        In = new InQualifier[] { InQualifier.Name },
        //        Language = Language.CSharp,
        //        Order = SortDirection.Descending,
        //        Size = new Octokit.Range(fromNumber, SearchQualifierOperator.GreaterThan),
        //        SortField = RepoSearchSort.Stars,
        //        Stars = new Octokit.Range(fromNumber, SearchQualifierOperator.GreaterThanOrEqualTo),
        //        Updated = new DateRange(fromDate, SearchQualifierOperator.GreaterThan),
        //        User = user
        //    };

        //    SearchRepositoryResult result = await client.Search.SearchRepo(request);
        //    Console.WriteLine($"Search.SearchRepo (All Fields): TotalCount={result.TotalCount}");
        //}
    }




}

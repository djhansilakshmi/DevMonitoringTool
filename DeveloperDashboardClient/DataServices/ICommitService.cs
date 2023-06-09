using Octokit;

namespace DeveloperDashboardClient.DataServices
{
    public interface ICommitService
    {
        Task<IReadOnlyList<GitHubCommit>> GetAllCommits(GitHubClient client);
    }
}

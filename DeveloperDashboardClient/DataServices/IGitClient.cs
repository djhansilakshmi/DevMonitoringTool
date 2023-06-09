using Octokit;

namespace DeveloperDashboardClient.DataServices
{
    public interface IGitClient
    {
        GitHubClient GetGithubClient();
    }
}

using Octokit;

namespace DeveloperDashboardClient.Client
{
    public interface IGitClient
    {
        GitHubClient GetGithubClient();
    }
}

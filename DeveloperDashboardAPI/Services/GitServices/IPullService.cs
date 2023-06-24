using DeveloperDashboardAPI.Dtos;

namespace DeveloperDashboardClient.Services.GitServices
{
    public interface IPullService
    {
        Task<List<PullRequest>> Get(string owner, string repo, string state = "all");
    }
}

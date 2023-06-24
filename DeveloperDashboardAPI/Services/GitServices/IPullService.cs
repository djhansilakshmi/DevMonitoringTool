using DashboardLibAPI.Dtos;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public interface IPullService
    {
        Task<List<PullRequest>> Get(string owner, string repo, string state = "all");
    }
}

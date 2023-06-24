using DeveloperDashboardAPI.Dtos;

namespace DeveloperDashboardClient.Services.GitServices
{
    public interface IBuildService
    {
        Task<Actions> Get(string owner, string repo);
    }
}

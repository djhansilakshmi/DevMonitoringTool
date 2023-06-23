using DeveloperDashboardClient.Dtos;

namespace DeveloperDashboardClient.DataServices.GitServices
{
    public interface IBuildService
    {
        Task<Actions> Get(string owner, string repo);
    }
}

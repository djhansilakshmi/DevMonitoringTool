using DashboardLib.Dtos;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public interface IBuildService
    {
        Task<Actions> Get(string owner, string repo);
    }
}

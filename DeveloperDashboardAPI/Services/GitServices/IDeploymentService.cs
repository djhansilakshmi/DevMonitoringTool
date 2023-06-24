using DashboardLib.Dtos;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public interface IDeploymentService
    {
        Task<List<Deployment>> Get(string owner, string repo, string state = "all");
    }
}

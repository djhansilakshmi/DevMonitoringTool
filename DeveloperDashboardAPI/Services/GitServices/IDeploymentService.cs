using DeveloperDashboardAPI.Dtos;

namespace DeveloperDashboardClient.Services.GitServices
{
    public interface IDeploymentService
    {
        Task<List<Deployment>> Get(string owner, string repo, string state = "all");
    }
}

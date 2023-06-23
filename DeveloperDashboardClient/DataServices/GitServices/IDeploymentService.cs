using DeveloperDashboardClient.Dtos;

namespace DeveloperDashboardClient.DataServices.GitServices
{
    public interface IDeploymentService
    {
        Task<List<Deployment>> Get(string owner, string repo, string state = "all");
    }
}

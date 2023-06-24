using DeveloperDashboardAPI.Dtos;

namespace DeveloperDashboardClient.Services.GitServices
{
    public interface IBranchService
    {
        Task<List<Branch>> GetAll(string owner, string repo);
    }
}

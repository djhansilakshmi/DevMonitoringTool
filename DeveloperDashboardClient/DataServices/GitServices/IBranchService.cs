using DeveloperDashboardClient.Dtos;

namespace DeveloperDashboardClient.DataServices.GitServices
{
    public interface IBranchService
    {
        Task<List<Branch>> GetAll(string owner, string repo);
    }
}

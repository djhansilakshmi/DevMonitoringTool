
using DashboardLib.Dtos;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public interface IBranchService
    {
        Task<Branch> Get(string owner, string repository, string branchName);
        Task<List<Branch>> GetAll(string owner, string repo);
    }
}

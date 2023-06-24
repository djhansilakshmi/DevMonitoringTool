
using DashboardLib.Dtos;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public interface IRepoService
    {
        Task<List<Repositories>> GetAll();
        Task<Repositories> GetRepo(string owner, string repoName);
    }
}

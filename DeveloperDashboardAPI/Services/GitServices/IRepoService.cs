using DeveloperDashboardAPI.Dtos;

namespace DeveloperDashboardClient.Services.GitServices
{
    public interface IRepoService
    {
        Task<List<Repositories>> GetAll();
    }
}

using DeveloperDashboardClient.Dtos;

namespace DeveloperDashboardClient.DataServices.GitServices
{
    public interface IRepoService
    {
        Task<List<Repositories>> GetAll();
    }
}

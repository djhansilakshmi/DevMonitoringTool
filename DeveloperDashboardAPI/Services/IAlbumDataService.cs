using DeveloperDashboard.Dtos;

namespace DeveloperDashboardAPI.Services.DataServices
{
    public interface IAlbumDataService
    {
        Task<Album[]> GetAllAlbums();
    }
}

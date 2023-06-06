using DeveloperDashboard.Dtos;

namespace DeveloperDashboard.DataServices
{
    public interface IAlbumDataService
    {
        Task<Album[]> GetAllAlbums();
    }
}

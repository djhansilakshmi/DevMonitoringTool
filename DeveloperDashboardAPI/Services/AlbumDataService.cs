using System.Net.Http.Json;

namespace DeveloperDashboardAPI.Services.DataServices
{
    public class AlbumDataService : IAlbumDataService
    {
        private readonly HttpClient _httpClient;

        public AlbumDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<Album[]> GetAllAlbums()
        //{
        //    var albums = await _httpClient.GetFromJsonAsync<Album[]>("/albums").ConfigureAwait(false);
        //    return albums;
        //}
    }
}

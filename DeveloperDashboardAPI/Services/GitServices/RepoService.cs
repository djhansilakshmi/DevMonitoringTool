using DeveloperDashboardAPI.Clients;
using DeveloperDashboardAPI.Dtos;
using Newtonsoft.Json;

namespace DeveloperDashboardClient.Services.GitServices
{
    public class RepoService : IRepoService
    {
        public readonly IGitClient _gitClient;

        public RepoService(IGitClient gitClient)
        {
            _gitClient = gitClient;
        }

        public async Task<List<Repositories>> GetAll()
        {
            var url = "user/repos";
            var responseContent = await _gitClient.SendAsync(url).ConfigureAwait(false);
            var repositories = JsonConvert.DeserializeObject<List<Repositories>>(responseContent);

            return repositories;
        }
    }
}

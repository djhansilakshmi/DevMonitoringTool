using DeveloperDashboardClient.Client;
using DeveloperDashboardClient.Dtos;
using Newtonsoft.Json;

namespace DeveloperDashboardClient.DataServices.GitServices
{
    public class RepoService : IRepoService
    {
        public readonly IGitClient _gitClientCalls;
        public RepoService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        public async Task<List<Repositories>> GetAll()
        {
            var responseContent = string.Empty;
            string url = "user/repos";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);

            var repositories = JsonConvert.DeserializeObject<List<Repositories>>(responseContent);

            return repositories;

        }
    }
}

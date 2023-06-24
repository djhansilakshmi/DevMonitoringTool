using DashboardLib.Dtos;
using DeveloperDashboardAPI.Clients;
using Newtonsoft.Json;

namespace DeveloperDashboardAPI.DataServices.GitServices
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

        public async Task<Repositories> GetRepo(string owner,string repoName)
        {
            var responseContent = string.Empty;
            string url = $"user/repos/{owner}/{repoName}";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);

            var repositories = JsonConvert.DeserializeObject<Repositories>(responseContent);

            return repositories;
        }
    }
}

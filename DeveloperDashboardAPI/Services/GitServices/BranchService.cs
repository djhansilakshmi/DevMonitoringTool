﻿using DeveloperDashboardAPI.Clients;
using DeveloperDashboardAPI.Dtos;
using DeveloperDashboardClient.Services.GitServices;
using Newtonsoft.Json;

namespace DeveloperDashboardAPI.Services.GitServices
{
    public class BranchService : IBranchService
    {
        public readonly IGitClient _gitClientCalls;
        public BranchService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        public async Task<List<Branch>> GetAll(string owner, string repo)
        {
            var responseContent = string.Empty;
            string url = $"repos/{owner}/{repo}/branches";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);

            var branches = JsonConvert.DeserializeObject<List<Branch>>(responseContent);

            return branches;
        }
    }
}

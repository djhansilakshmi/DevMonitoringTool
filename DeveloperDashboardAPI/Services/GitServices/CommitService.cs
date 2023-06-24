using DeveloperDashboardAPI.Clients;

namespace DeveloperDashboardClient.Services.GitServices
{
    public class CommitService : ICommitService
    {
        public readonly IGitClient _gitClientCalls;
        public CommitService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }
    }
}

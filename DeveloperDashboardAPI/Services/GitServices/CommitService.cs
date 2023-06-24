using DeveloperDashboardAPI.Clients;

namespace DeveloperDashboardAPI.DataServices.GitServices
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

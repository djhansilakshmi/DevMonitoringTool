using DeveloperDashboardClient.Client;

namespace DeveloperDashboardClient.DataServices.GitServices
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

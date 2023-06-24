using DeveloperDashboardClient.Dtos;

namespace DeveloperDashboardClient.DataServices.DeepSourceServices
{
    public interface ICodeCoverage
    {
        Task<CodeCoverage> Get(string owner, string repo, string vcsprovider = "GITHUB");
    }
}

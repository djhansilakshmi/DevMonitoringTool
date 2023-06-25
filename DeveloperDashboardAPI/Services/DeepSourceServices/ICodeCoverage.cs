using DashboardLib.Dtos;

namespace DeveloperDashboardAPI.DataServices.DeepSourceServices
{
    public interface ICodeCoverage
    {
        Task<CodeCoverage> Get(string owner, string repo, string vcsprovider = "GITHUB");
    }
}

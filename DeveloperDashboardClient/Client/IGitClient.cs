using System.Threading.Tasks;

namespace DeveloperDashboardClient.Client
{
    public interface IGitClient
    {
        Task<string> SendAsync(string url);
    }
}

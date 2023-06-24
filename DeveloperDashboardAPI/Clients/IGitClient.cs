namespace DeveloperDashboardAPI.Clients
{
    public interface IGitClient
    {
        Task<string> SendAsync(string url);
    }
}

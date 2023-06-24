namespace DeveloperDashboardClient.Client
{
    public interface IDeepsourceClient
    {
        Task<string> SendAsync(string url, string data);
    }
}

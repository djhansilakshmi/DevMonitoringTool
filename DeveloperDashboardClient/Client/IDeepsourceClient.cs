namespace DeveloperDashboardClient.Client
{
    public interface IDeepsourceClient
    {
        // Task<HttpResponseMessage> SendAsync(string data);
        Task<string> SendAsync(string data);
    }
}

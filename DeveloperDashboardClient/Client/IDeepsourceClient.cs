namespace DeveloperDashboardClient.Client
{
    public interface IDeepsourceClient
    {
        Task<HttpResponseMessage> SendAsync(string data);
    }
}

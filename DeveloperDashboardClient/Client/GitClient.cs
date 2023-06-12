using Octokit;
using System.Reflection;

namespace DeveloperDashboardClient.Client
{
    public class GitClient : IGitClient
    {
        private static string GitHubIdentity = Assembly
            .GetEntryAssembly()
            .GetCustomAttribute<AssemblyProductAttribute>()
            .Product;

        private ProductHeaderValue _productInformation;

        private readonly string _token;

        public GitClient(string token)
        {
            _productInformation = new ProductHeaderValue(GitHubIdentity);
            _token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>GitHubClient</returns>
        public GitHubClient GetGithubClient()
        {
            var client = AuthenticateToken();
            return client;
        }

        private GitHubClient AuthenticateToken()
        {
            return GethubClient();
        }

        private GitHubClient GethubClient()
        {
            var credentials = new Credentials(_token);
            var client = new GitHubClient(_productInformation) { Credentials = credentials };
            return client;
        }


    }
}


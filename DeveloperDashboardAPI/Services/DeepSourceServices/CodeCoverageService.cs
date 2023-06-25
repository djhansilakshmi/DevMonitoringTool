using DeveloperDashboardAPI.Client;
using DashboardLibAPI.Dtos;
using Newtonsoft.Json;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DeveloperDashboardAPI.DataServices.DeepSourceServices
{
    public class CodeCoverageService : ICodeCoverage
    {
        public readonly IDeepsourceClient _deepsourceClientCalls;
        public CodeCoverageService(IDeepsourceClient deepsourceCalls)
        {
            _deepsourceClientCalls = deepsourceCalls;
        }

        public async Task<CodeCoverage> Get(string owner, string repo, string vcsprovider = "GITHUB")
        {
                var responseContent = string.Empty;
                string data = @"{repository( name:"""+repo+@""",login:"""+owner+@""",vcsProvider:GITHUB){name  id metrics{name items {id values{ edges{node {value valueDisplay threshold thresholdStatus}} } }  }}}";
                responseContent = await _deepsourceClientCalls.SendAsync(data).ConfigureAwait(false);
                var codeCoverage = JsonConvert.DeserializeObject<CodeCoverage>(responseContent);
                return codeCoverage;
        }

      
    }
}

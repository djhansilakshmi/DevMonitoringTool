using DeveloperDashboardClient.Client;
using DeveloperDashboardClient.Dtos;
using Newtonsoft.Json;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DeveloperDashboardClient.DataServices.DeepSourceServices
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
            try
            {

                var responseContent = string.Empty;
                string data = getdata(); 
                
                var res =  _deepsourceClientCalls.SendAsync(data).GetAwaiter().GetResult();

                var stream = await res.Content.ReadAsStreamAsync();
                var codeCoverage = string.Empty;
                using (JsonReader jsonReader = new JsonTextReader(new System.IO.StreamReader(stream)))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<CodeCoverage>(jsonReader);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        private string getdata()
        {

            string data = @"{ repository( name:\""DevMonitoringTool"",
                                  login:""djhansilakshmi"",     
                                  vcsProvider:GITHUB
                                )
                                {   name
                                    id
                                    metrics
                                    {
                                        name         
                                        description
                                        positiveDirection
                                        unit            
                                        minValueAllowed
                                        maxValueAllowed
                                        isThresholdEnforced 
                                        isReported
                                        items{
                                            id
                                            key
                                            threshold
                                            latestValue
                                            latestValueDisplay
                                            thresholdStatus
                                            values
                                            {
                                                pageInfo
                                                {
                                                    hasNextPage
                                                    hasPreviousPage
                                                    startCursor
                                                    endCursor
                                                }
                                                edges
                                                {
                                                 node
                                                 {
                                                     id
                                                     value
                                                     valueDisplay
                                                     threshold
                                                     thresholdStatus
                                                     commitOid
                                                     createdAt
                                                 }
                                                 cursor
                                                }
                                                totalCount
                                            }                
                                        }  
                                    }
                                }  		    
                            }";

            return data.Replace("\n","");
        }
    }
}

using System.Threading.Tasks;
using AuditAppPcl.Repository.Contracts;
using AuditAppPcl.RestClient;
using AuditAppPcl.Entities.Request;
using AuditAppPcl.Entities.Response;

namespace AuditAppPcl.Repository.Concrete
{
    public class CaseServiceRepository : ICaseServiceRepository
    {
        public IRestClient restClient;

        public CaseServiceRepository(IRestClient restClient)
        {
            this.restClient = restClient;
            this.restClient.BaseUrl = Settings.Settings.UserServicePath;
        }

        public async Task<GetCasesResponse> GetCases()
        {
            var casesRequest = new GetCasesRequest();
            casesRequest.LoginToken = Settings.Settings.LoginToken;
            casesRequest.Username = Settings.Settings.Username;
            return await restClient.GetAsync<GetCasesResponse>("GetCases", casesRequest);
        }

        public async Task<GetCasesWithAuditsResponse> GetCasesWithAudits()
        {
            var casesRequest = new GetCasesWithAuditsRequest();
            casesRequest.LoginToken = Settings.Settings.LoginToken;
            casesRequest.Username = Settings.Settings.Username;
            return await restClient.GetAsync<GetCasesWithAuditsResponse>("GetCasesWithAudits", casesRequest);
        }
    }
}

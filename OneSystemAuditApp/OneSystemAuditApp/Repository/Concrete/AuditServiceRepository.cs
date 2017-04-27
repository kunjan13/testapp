using AuditAppPcl.Entities;
using AuditAppPcl.Entities.Request;
using AuditAppPcl.Entities.Response;
using AuditAppPcl.Repository.Contracts;
using AuditAppPcl.RestClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Concrete
{
    public class AuditServiceRepository : IAuditServiceRepository
    {
        public IRestClient restClient;

        public AuditServiceRepository(IRestClient restClient) {
            this.restClient = restClient;
            this.restClient.BaseUrl = Settings.Settings.UserServicePath;
        }

        public async Task<List<Audit>> GetAudits()
        {
            var auditsRequest = new GetAuditsRequest();
            auditsRequest.LoginToken = Settings.Settings.LoginToken;
            auditsRequest.Username = Settings.Settings.Username;
            var data = await restClient.PostAsync<GetAuditsRequest, GetAuditsResponse>("GetAudits", auditsRequest);
            if (data.Sucsess) {
                for (int i = 0; i < 75; i++)
                {
                    data.Audits.Add(data.Audits[0]);
                }
                return data.Audits;
            }
            return null;
        }

        public async Task<GetSystemDataResponse> GetSystemData()
        {
            var systemDataRequest = new GetSystemDataRequest();
            systemDataRequest.LoginToken = Settings.Settings.LoginToken;
            systemDataRequest.Username = Settings.Settings.Username;
            return await restClient.PostAsync<GetSystemDataRequest, GetSystemDataResponse>("GetSystemData", systemDataRequest);
        }

        public async Task<List<Entities.AuditTemp>> GetAuditsTemp()
        {
            var client = new HttpClient();
            var data = await restClient.GetAsync<List<Entities.AuditTemp>>("posts");
            //var audits = JsonConvert.DeserializeObject<List<Audit>>(data);
            return data;
        }

        public Task<Audit> UploadAudit(Audit Audit)
        {
            throw new NotImplementedException();
        }
    }
}

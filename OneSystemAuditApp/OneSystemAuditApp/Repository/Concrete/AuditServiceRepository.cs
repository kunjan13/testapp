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
            this.restClient.BaseUrl = Settings.Settings.UserServicePath + "/";
        }

        public async Task<List<Audit>> GetAudits()
        {
            var auditsRequest = new GetAuditsRequest();
            auditsRequest.LoginToken = "nfqG63uyhP7TcEmD9Et0bJdob9E48SPzad1EgbQebmSaARENB3NgbvveCC4wZZ0YA8iych";//Settings.Settings.LoginToken;
            auditsRequest.Username = "gatewayuser";//Settings.Settings.Username;
            auditsRequest.GetAttachments = true;
            auditsRequest.ItemIDs = new List<string>();
            //var data = await restClient.PostAsync<GetAuditsRequest, GetAuditsResponse>("GetAudits", auditsRequest);
            var data = Task.Run(async () => await restClient.PostAsync<GetAuditsRequest, GetAuditsResponse>("GetAudits", auditsRequest)).Result;
            if (data.Sucsess) {
                //for (int i = 0; i < 75; i++)
                //{
                //    data.Audits.Add(data.Audits[0]);
                //}
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

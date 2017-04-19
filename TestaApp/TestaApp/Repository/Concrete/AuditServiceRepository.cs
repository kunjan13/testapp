using AuditAppPcl.Entities;
using AuditAppPcl.Entities.Response;
using AuditAppPcl.Repository.Contracts;
using AuditAppPcl.RestClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Concrete
{
    public class AuditServiceRepository : IAuditServiceRepository
    {
        public IRestClient restClient;
        private readonly string baseUrl = "http://10.0.3.126:84/api/default";

        public AuditServiceRepository(IRestClient restClient) {
            this.restClient = restClient;
            this.restClient.BaseUrl = baseUrl;
        }

        public async Task<List<Audit>> GetAudits()
        {
            var client = new HttpClient();
            var data = await restClient.GetAsync<GetAuditsforUserResponse>("");
            if (data.Sucsess) {
                for (int i = 0; i < 75; i++)
                {
                    data.Audits.Add(data.Audits[0]);
                }
                return data.Audits;
            }
            return null;
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

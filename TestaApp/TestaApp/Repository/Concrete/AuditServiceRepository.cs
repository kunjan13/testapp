using AuditAppPcl.Entities.Database;
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
        private readonly string baseUrl = "https://jsonplaceholder.typicode.com/";

        public AuditServiceRepository(IRestClient restClient) {
            this.restClient = restClient;
            this.restClient.BaseUrl = baseUrl;
        }

        public async Task<List<Audit>> GetAudits()
        {
            var client = new HttpClient();
            var data = await restClient.GetAsync<List<Audit>>(baseUrl + "posts");
            return data;
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

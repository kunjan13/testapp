using AuditAppPcl.Repository.Contracts;
using AuditAppPcl.RestClient;
using AuditAppPcl.Entities.Response;
using AuditAppPcl.Entities.Request;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        public readonly IRestClient restClient;
        public LoginRepository(IRestClient restClient)
        {
            this.restClient = restClient;
            this.restClient.BaseUrl = Settings.Settings.ApiUrl;
        }

        public GetServicePathResponse GetServicePath(string companyPin)
        {
            var servicePathRequest = new GetServicePathRequest();
            servicePathRequest.CompanyPin = companyPin;

            var data = Task.Run(async () => await restClient.PostAsync<GetServicePathRequest, GetServicePathResponse>("", servicePathRequest)).Result;
            return data;
        }

        public LoginResponse LoginUser(string userName, string password)
        {
            //var data = Task.Run(async () => await RequestApiForLogin(userName, password)).Result;
            //return data;

            return new LoginResponse()
            {
                Success = true,
                LoginToken = "VOxtjHsQ20VaBaaUm7lTONVY8epxG5kKJ0dL1BKsXRziY2iCCfgEL3YIs9VFRvKxgK0awYsl"
            };
        }

        async Task<LoginResponse> RequestApiForLogin(string userName, string password)
        {
            var loginRequest = new LoginRequest();
            loginRequest.Username = userName;
            loginRequest.Password = password;

            return await restClient.PostAsync<LoginRequest, LoginResponse>("Login", loginRequest);
        }


    }
}

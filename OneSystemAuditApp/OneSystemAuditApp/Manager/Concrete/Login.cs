using System;
using AuditAppPcl.Entities.Response;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Contracts;

namespace AuditAppPcl.Manager.Concrete
{
    public class Login : ILogin
    {
        public ILoginRepository loginRepository;

        public Login(ILoginRepository loginRepository) {
            this.loginRepository = loginRepository;
        }

        public GetServicePathResponse GetServicePath(string companyPin)
        {
            var getServicePathResponce = new GetServicePathResponse();
            App.TownName = string.Empty;
            getServicePathResponce =  this.loginRepository.GetServicePath(companyPin);
            if(getServicePathResponce == null && !getServicePathResponce.Sucsess)
            {
                getServicePathResponce.Sucsess = false;
            }
            else
            {
                getServicePathResponce.Sucsess = true;
                App.TownName = getServicePathResponce.Company;
                Settings.Settings.UserServicePath = getServicePathResponce.ServicePath;
            }
            return getServicePathResponce;
        }

        public LoginResponse LoginUser(string userName, string password)
        {
            var loginResponse = new LoginResponse();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                loginResponse.Success = false;
                loginResponse.ErrorMessage = Resources.AppResources.EmptyUsernamePassword;
                return loginResponse;
            }
            loginResponse = loginRepository.LoginUser(userName, password);

            if (loginResponse == null && !loginResponse.Success)
            {
                loginResponse.Success = false;
                loginResponse.ErrorMessage = Resources.AppResources.InvalidCredentials;
            }
            else
            {
                loginResponse.Success = true;
                //Store login token and username in account store
                Settings.Settings.LoginToken = loginResponse.LoginToken;
                Settings.Settings.Username = userName;
                App.IsUserLoggedIn = true;
                App.LoginToken = loginResponse.LoginToken;
                App.Username = userName;
            }
            return loginResponse;
        }
    }
}

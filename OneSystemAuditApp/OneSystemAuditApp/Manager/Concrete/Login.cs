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
            //set town name 
            App.TownName = string.Empty;
            return this.loginRepository.GetServicePath(companyPin);
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

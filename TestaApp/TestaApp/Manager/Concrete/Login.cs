using AuditAppPcl.Entities;
using AuditAppPcl.Entities.Response;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Manager.Concrete
{
    public class Login : ILogin
    {
        public ILoginRepository loginRepository;

        public Login(ILoginRepository loginRepository) {
            this.loginRepository = loginRepository;
        }
        public LoginResponse LoginUser(string userName, string password)
        {
            var loginResponse = new LoginResponse();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                loginResponse.Status = LoginResponse.LoginStatus.error;
                loginResponse.ErrorMessage = Resources.AppResources.EmptyUsernamePassword;
                return loginResponse;
            }

            var user = loginRepository.LoginUser(userName, password);

            if (user == null)
            {
                loginResponse.Status = LoginResponse.LoginStatus.error;
                loginResponse.ErrorMessage = Resources.AppResources.InvalidCredentials;
            }
            else
            {
                loginResponse.User = user;
                loginResponse.Status = LoginResponse.LoginStatus.success;
            }

            return loginResponse;
        }
    }
}

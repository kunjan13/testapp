using System;
using AuditAppPcl.Repository.Contracts;
using AuditAppPcl.Entities;

namespace AuditAppPcl.Repository.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        public User LoginUser(string userName, string password)
        {
            var isValid = AreCredentialsCorrect(userName, password);
            if (isValid) {
                return new Entities.User()
                {
                    Username = userName,
                    Password = password,
                    Email = "recieved from api"
                };
            }
            //return invalid credentials
            return new User()
            {
                ErrorMessage = Resources.AppResources.InvalidCredentials
            };
        }

        bool AreCredentialsCorrect(string userName, string password)
        {
            return userName == "Test" && password == "pass";
        }
    }
}

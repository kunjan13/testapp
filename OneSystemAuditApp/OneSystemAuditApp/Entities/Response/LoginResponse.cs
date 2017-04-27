using System.Collections.Generic;
namespace AuditAppPcl.Entities.Response
{
    public class LoginResponse
    {
        public bool Success { get; set; }

        public List<string> Exception { get; set; }

        public string ErrorMessage { get; set; }

        public string LoginToken { get; set; }

        public User User { get; set; }
    }
}

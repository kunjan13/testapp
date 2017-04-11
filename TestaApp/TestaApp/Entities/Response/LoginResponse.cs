using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities.Response
{
    public class LoginResponse
    {
        public enum LoginStatus
        {
            success, error
        }
        public LoginStatus Status { get; set; }

        public string ErrorMessage { get; set; }

        public User User { get; set; }
    }
}

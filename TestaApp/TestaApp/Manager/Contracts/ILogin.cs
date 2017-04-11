using AuditAppPcl.Entities;
using AuditAppPcl.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Manager.Contracts
{
    public interface ILogin
    {
        LoginResponse LoginUser(string userName, string password);
    }
}

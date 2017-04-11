using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities;

namespace AuditAppPcl.Repository.Contracts
{
    public interface ILoginRepository
    {
        User LoginUser(string userName, string password);
    }
}

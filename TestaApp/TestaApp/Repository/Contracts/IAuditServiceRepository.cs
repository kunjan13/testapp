using AuditAppPcl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Contracts
{
    public interface IAuditServiceRepository
    {
        Task<List<Audit>> GetAudits();
    }
}

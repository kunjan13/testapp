using AuditAppPcl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Manager.Contracts
{
    public interface IAuditServiceManager
    {
        Task<List<AuditTemp>> GetAuditsTemp();
        Task<List<Audit>> GetAudits();

        Task<int> DownloadAudit(string serviceAuditId);
    }
}

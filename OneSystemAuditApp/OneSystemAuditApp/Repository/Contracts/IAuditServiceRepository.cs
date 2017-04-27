using AuditAppPcl.Entities;
using AuditAppPcl.Entities.Response;
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

        Task<Audit> UploadAudit(Audit Audit);

        Task<List<Entities.AuditTemp>> GetAuditsTemp();

        Task<GetSystemDataResponse> GetSystemData();
    }
}

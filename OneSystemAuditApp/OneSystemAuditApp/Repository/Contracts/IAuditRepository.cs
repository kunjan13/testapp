using AuditAppPcl.Entities.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Contracts
{
    public interface IAuditRepository
    {
        Task<List<Audit>> GetAudits();

        Task<List<string>> GetAuditIds();

        Task<Audit> GetAuditById(int id);

        Task InsertAudit(Audit audit);

        Task InsertAudits(List<Audit> audits);
    }
}

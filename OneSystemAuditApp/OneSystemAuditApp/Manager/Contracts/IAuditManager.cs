using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities;

namespace AuditAppPcl.Manager.Contracts
{
    public interface IAuditManager
    {
        Task InsertAudits(List<Audit> audits);
    }
}

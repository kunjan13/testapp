using AuditAppPcl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Manager.Contracts
{
    public interface ICaseServiceManager
    {
        List<Case> GetCases();

        List<Case> GetCasesWithAudits();
    }
}

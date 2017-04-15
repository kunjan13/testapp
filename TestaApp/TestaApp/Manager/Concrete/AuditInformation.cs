using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Contracts;

namespace AuditAppPcl.Manager.Concrete
{
    public class AuditInformation : IAuditInformation
    {
        public IAuditRepository auditRepositoryService;
        public AuditInformation(IAuditRepository auditInformationService)
        {
            this.auditRepositoryService = auditInformationService;
        }
        public Task<Audit> GetAudit()
        {
            throw new NotImplementedException();
        }
    }
}

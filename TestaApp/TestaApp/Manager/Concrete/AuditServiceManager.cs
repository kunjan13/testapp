using AuditAppPcl.Entities;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Manager.Concrete
{
    public class AuditServiceManager : IAuditServiceManager
    {
        public IAuditServiceRepository auditServiceRepository;
        public AuditServiceManager(IAuditServiceRepository auditServiceRepository)
        {
            this.auditServiceRepository = auditServiceRepository;
        }

        public async Task<List<Audit>> GetAudits()
        {
            var data = await auditServiceRepository.GetAudits();
            return data;
        }
    }
}

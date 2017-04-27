using AuditAppPcl.Manager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities;
using AuditAppPcl.Repository.Contracts;

namespace AuditAppPcl.Manager.Concrete
{
    public class CaseServiceManager : ICaseServiceManager
    {
        private readonly ICaseServiceRepository caseServiceRepository;

        public CaseServiceManager(ICaseServiceRepository caseServiceRepository)
        {
            this.caseServiceRepository = caseServiceRepository;
        }
        public List<Case> GetCases()
        {
            var data = Task.Run(async () => await caseServiceRepository.GetCases()).Result;
            if(data != null && data.Success)
            {
                return data.Cases;
            }
            return null;
        }

        public List<Case> GetCasesWithAudits()
        {
            var data = Task.Run(async () => await caseServiceRepository.GetCasesWithAudits()).Result;
            if (data != null && data.Success)
            {
                return data.Cases;
            }
            return null;
        }
    }
}

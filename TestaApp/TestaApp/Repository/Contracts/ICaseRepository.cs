using AuditAppPcl.Entities.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Contracts
{
    public interface ICaseRepository
    {
        Task<List<Case>> GetCases();
    }
}

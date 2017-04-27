using AuditAppPcl.Entities.Response;
using System.Threading.Tasks;

namespace AuditAppPcl.Repository.Contracts
{
    public interface ICaseServiceRepository
    {
        Task<GetCasesResponse> GetCases();

        Task<GetCasesWithAuditsResponse> GetCasesWithAudits();
    }
}

using AuditAppPcl.Entities.Response;

namespace AuditAppPcl.Repository.Contracts
{
    public interface ILoginRepository
    {
        LoginResponse LoginUser(string userName, string password);

        GetServicePathResponse GetServicePath(string companyPin);
    }
}

using System.Collections.Generic;
namespace AuditAppPcl.Entities.Response
{
    public class GetAuditsResponse
    {
        public List<Audit> Audits { get; set; }
        public bool Sucsess { get; set; }
        public List<string> Exception { get; set; }
    }
}

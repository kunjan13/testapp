using System.Collections.Generic;

namespace AuditAppPcl.Entities.Response
{
    public class GetCasesWithAuditsResponse
    {
        public List<Case> Cases { get; set; }
        public bool Success { get; set; }
        public List<string> Exception { get; set; }
    }
    
}
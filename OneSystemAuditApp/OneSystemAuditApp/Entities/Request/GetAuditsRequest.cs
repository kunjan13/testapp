using System;
using System.Collections.Generic;
using System.Linq;
namespace AuditAppPcl.Entities.Request
{
    public class GetAuditsRequest
    {
        public string Username { get; set; }
        public string LoginToken { get; set; }
        public bool GetAttachments { get; set; }
        public List<string> ItemIDs { get; set; }
    }
}

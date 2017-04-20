using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities.Response
{
    public class GetAuditsforUserResponse
    {
        public List<Audit> Audits { get; set; }
        public bool Sucsess { get; set; }
        public List<string> Exception { get; set; }
    }
}

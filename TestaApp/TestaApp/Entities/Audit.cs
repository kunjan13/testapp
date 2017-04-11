using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities
{
    public class Audit
    {
        public string Id { get; set; }
        public string userId { get; set; }

        public string title { get; set; }
        public string Description { get; set; }

        public string body { get; set; }
    }
}

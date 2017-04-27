using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities
{
    public class MenuItems
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public Type TargetType { get; set; }
    }
}

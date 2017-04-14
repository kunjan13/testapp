using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities.Database
{
    public class BuildingOfficer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int AuditAppOfficerId { get; set; }

        public string Name { get; set; }
        public string ItemID { get; set; }
    }
}

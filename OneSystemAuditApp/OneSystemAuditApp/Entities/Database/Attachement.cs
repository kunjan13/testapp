using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities.Database
{
    public class Attachement
    {
        [PrimaryKey, AutoIncrement]
        public int AuditAppAttachementId { get; set; }

        [ForeignKey(typeof(Audit))]
        public int AuditAppId { get; set; }

        public string ItemID { get; set; }
        public string Comments { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }

        [ManyToOne]
        public Audit Audit { get; set; }
    }
}

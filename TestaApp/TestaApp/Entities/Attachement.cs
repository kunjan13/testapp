using System.Collections.Generic;

namespace AuditAppPcl.Entities
{
    public class Attachement
    {
        public int AuditAppAttachementId { get; set; }

        public string ItemID { get; set; }
        public List<Comment> Comments { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public string StringComment { get; set; }
    }
}
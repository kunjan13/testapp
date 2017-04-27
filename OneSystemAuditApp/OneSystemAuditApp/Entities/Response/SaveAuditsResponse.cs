using System.Collections.Generic;
namespace AuditAppPcl.Entities.Response
{
    public class SaveAuditResponse
    {
         public bool Success { get; set; }
         public List<string> Exception { get; set; }
         public string ItemID { get; set; }
    }
}
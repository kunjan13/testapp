namespace AuditAppPcl.Entities.Request
{
    public class SaveAuditRequest
    {
        public string LoginToken { get; set; }
        public string Username { get; set; }
        public Audit Audit { get; set; }
    }
}
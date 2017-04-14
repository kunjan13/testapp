using System;

namespace AuditAppPcl.Entities
{
    public class Comment
    {
        public int AuditAppCommentId { get; set; }

        public string CommentText { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
        public string RefID { get; set; }
    }
}
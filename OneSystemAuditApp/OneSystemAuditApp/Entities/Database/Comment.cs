using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities.Database
{
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int AuditAppCommentId { get; set; }

        public string CommentText { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
        public string RefID { get; set; }
    }
}

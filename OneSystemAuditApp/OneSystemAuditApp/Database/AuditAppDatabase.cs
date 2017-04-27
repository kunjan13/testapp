using AuditAppPcl.Entities.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Database
{
    public class AuditAppDatabase
    {
        readonly SQLiteAsyncConnection database;

        public AuditAppDatabase(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Comment>().Wait();
            database.CreateTableAsync<Attachement>().Wait();
            database.CreateTableAsync<Audit>().Wait();
        }

        public Task<List<Audit>> GetAudits()
        {
            return database.Table<Audit>().ToListAsync();
        }

        public Task<Audit> GetAuditById(int id)
        {
            return database.Table<Audit>().Where(i => i.AuditAppId == id).FirstOrDefaultAsync();
        }

        public Task<List<Audit>> GetAuditIds()
        {
            return database.QueryAsync<Audit>("SELECT ItemID FROM [Audit]");
        }

        public async Task InsertAudit(Audit audit)
        {
            await database.RunInTransactionAsync(trans => {
                
                foreach (var attachment in audit.Attachements)
                {
                    trans.Insert(attachment);
                }
                foreach (var comment in audit.Comments)
                {
                    trans.Insert(comment);
                }
                trans.Insert(audit);
            });
        }

    }
}

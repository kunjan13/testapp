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
            try
            {
                database = new SQLiteAsyncConnection(databasePath);
                database.CreateTableAsync<Audit>().Wait();
                database.CreateTableAsync<Attachement>().Wait();
                database.CreateTableAsync<Case>().Wait();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<List<Audit>> GetAudits()
        {
            return database.Table<Audit>().ToListAsync();
        }

        public Task<List<Audit>> GetActiveAudits()
        {
            try
            {
                return database.QueryAsync<Audit>("SELECT * FROM [Audit] WHERE UserName IS NULL");
            }
            catch(Exception e)
            {
                throw e;
            }
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
                trans.Insert(audit);
            });
        }

        public async Task InsertAudits(List<Audit> audits)
        {
            try
            {
                await database.RunInTransactionAsync(trans =>
                {
                    foreach (var audit in audits)
                    {
                        trans.Insert(audit);
                        if (audit.Attachements == null)
                        {
                            audit.Attachements = new List<Attachement>();
                        }

                        foreach (var attachment in audit.Attachements)
                        {
                            attachment.AuditAppId = audit.AuditAppId;
                            trans.Insert(attachment);
                        }

                        //var updatedAudit = database.QueryAsync<Audit>("select * from Audit where ItemID = ? and UserName != null", audit.ItemID).Result.FirstOrDefault();
                        //bool updateAttachment = true;
                        //if(updatedAudit != null)
                        //{
                        //    if(updatedAudit.UserName == null)
                        //    {
                        //        trans.Update(audit);
                        //    }
                        //}else
                        //{
                        //    trans.Insert(audit);
                        //    updateAttachment = true;
                        //}

                        //if (updateAttachment)
                        //{
                        //    trans.Execute("delete from Attachement where AuditAppId = ?", audit.AuditAppId);

                        //    if (audit.Attachements == null)
                        //    {
                        //        audit.Attachements = new List<Attachement>();
                        //    }

                        //    foreach (var attachment in audit.Attachements)
                        //    {
                        //        attachment.AuditAppId = audit.AuditAppId;
                        //        trans.Insert(attachment);
                        //    }
                        //}
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

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
            try
            {
                var audits = database.Table<Audit>().ToListAsync();
                foreach (var audit in audits.Result)
                {
                    var attachments = database.QueryAsync<Attachement>("select * from Attachement where AuditAppId = ?", audit.AuditAppId).Result;
                    foreach (var attachment in attachments)
                    {
                        audit.Attachements = new List<Attachement>();
                        audit.Attachements.Add(attachment);
                    }
                }

                return audits;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<Case> GetCaseById(int caseId)
        {
            try
            {
                var selectedCase = database.Table<Case>().Where(i => i.AuditAppCaseId == caseId).FirstOrDefaultAsync();
                var audits = database.Table<Audit>().Where(i => i.AuditAppCaseId == caseId).ToListAsync().Result;
                selectedCase.Result.Audits = new List<Audit>();
                selectedCase.Result.Audits.AddRange(audits);
                return selectedCase;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public  Task<List<Audit>> GetMyAudits(string userName)
        {
            try
            {
                return  database.Table<Audit>().Where(i => i.UserName == userName).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<List<Case>> GetCases()
        {
            try
            {
                return database.Table<Case>().ToListAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Task<Audit> GetAuditById(int id)
        {
            try
            {
                var audit = database.Table<Audit>().Where(i => i.AuditAppId == id).FirstOrDefaultAsync();
                var attachments = database.Table<Attachement>().Where(i => i.AuditAppId == id).ToListAsync().Result;
                audit.Result.Attachements = new List<Attachement>();
                audit.Result.Attachements.AddRange(attachments);
                return audit;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Audit>> GetAuditIds()
        {
            Audit ad = new Audit();
            var res = await database.DeleteAsync(ad);
            return null;// database.QueryAsync<Audit>("SELECT ItemID FROM [Audit]");
        }

        public async Task InsertAudit(Audit audit)
        {
            await database.RunInTransactionAsync(trans =>
            {

                trans.Insert(audit);
                foreach (var attachment in audit.Attachements)
                {
                    trans.Insert(attachment);
                }
            });
        }

        public async Task InsertAudits(List<Audit> audits)
        {
            await database.RunInTransactionAsync(trans =>
            {
                //trans.InsertAll(audits);
                foreach (var audit in audits)
                {
                    trans.Insert(audit);

                    foreach (var attachment in audit.Attachements)
                    {
                        attachment.AuditAppId = audit.AuditAppId;
                        trans.Insert(attachment);
                    }
                }

            });
        }

        public async Task<bool> UpdateAudit(Audit audit)
        {
            try
            {
                bool returnValue = false;
                await database.RunInTransactionAsync(trans =>
                {
                    trans.Update(audit);
                    //var result;
                    trans.Execute("delete from Attachement where AuditAppId = ?", audit.AuditAppId);

                    foreach (var attachment in audit.Attachements)
                    {
                        trans.Insert(attachment);
                    }
                    returnValue = true;
                });
                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteAudit(Audit audit)
        {
            try
            {
                bool returnValue = false;
                await database.RunInTransactionAsync(trans =>
                {
                    trans.Delete(audit);
                    foreach(var attachment in audit.Attachements)
                    {
                        trans.Delete(attachment);
                    }
                    returnValue = true;
                });
                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

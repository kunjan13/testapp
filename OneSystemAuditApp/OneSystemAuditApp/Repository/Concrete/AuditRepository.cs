using AuditAppPcl.Database;
using AuditAppPcl.Entities.Database;
using AuditAppPcl.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuditAppPcl.Repository.Concrete
{
    public class AuditRepository : IAuditRepository
    {
        AuditAppDatabase database;

        public AuditAppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AuditAppDatabase(DependencyService.Get<IDatabaseHelper>().GetLocalFilePath("AuditAppTest.db3"));
                }
                return database;
            }
        }

        public AuditRepository()
        {
            database = Database;
        }

        public async Task<List<Audit>> GetAudits()
        {
            return await database.GetAudits();
        }

        public async Task<List<string>> GetAuditIds()
        {
            var data = await database.GetAuditIds();
            return data.Select(x => x.ItemID).ToList();
        }

        public async Task<Audit> GetAuditById(int id)
        {
            return await database.GetAuditById(id);
        }

        public async Task InsertAudit(Audit audit)
        {
            await database.InsertAudit(audit);
        }

        public async Task InsertAudits(List<Audit> audits)
        {
            await database.InsertAudits(audits);
        }

        public async Task<List<Audit>> GetActiveAudits()
        {
            return await database.GetActiveAudits();
        }
    }
}

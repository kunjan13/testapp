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
    public class CaseRepository: ICaseRepository
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

        public CaseRepository()
        {
            database = Database;
        }

        public async Task<List<Case>> GetCases()
        {
            return await database.GetCases();
        }

        public async Task<Case> GetCaseById(int caseId)
        {
            return await database.GetCaseById(caseId);
        }
    }
}

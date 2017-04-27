using AuditAppPcl.Entities;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities.Response;

namespace AuditAppPcl.Manager.Concrete
{
    public class AuditServiceManager : IAuditServiceManager
    {
        public IAuditServiceRepository auditServiceRepository;
        public IAuditRepository auditRepository;
        public AuditServiceManager(IAuditServiceRepository auditServiceRepository, IAuditRepository auditRepository)
        {
            this.auditServiceRepository = auditServiceRepository;
            this.auditRepository = auditRepository;
        }

        public async Task<List<Audit>> GetAudits()
        {
            var serviceData = await auditServiceRepository.GetAudits();

            //var downloadedAuditIds = await auditRepository.GetAuditIds();

            //var audits = serviceData.Select(x => new Audit()
            //{
            //    IsDownloaded = (downloadedAuditIds.Any(i => i == x.ItemID)),
            //    ApplicantName = x.ApplicantName,
            //    AuditAppId = x.AuditAppId,
            //    CaseUID = x.CaseUID,
            //    CaseSubject = x.CaseSubject,
            //    IsSynced = x.IsSynced,
            //    SyncedDateTime = x.SyncedDateTime,
            //    ParentID = x.ParentID,
            //    ItemID = x.ItemID,
            //    Signature = x.Signature,
            //    SignatureIMG = x.SignatureIMG
            //}).ToList();

            return serviceData;
        }

        public async Task<List<AuditTemp>> GetAuditsTemp()
        {
            var serviceData = await auditServiceRepository.GetAuditsTemp();
            return serviceData;
        }

        public async Task<int> DownloadAudit(string serviceAuditId)
        {
            //var serviceData = await auditServiceRepository.GetAudits();
            //var downloadAudit = serviceData.Where(x => x.ItemID == serviceAuditId).FirstOrDefault();
            //if (downloadAudit != null)
            //{
            //    await auditRepository.InsertAudit(downloadAudit);
            //    return 1;
            //}
            return -1;
        }

        public async Task<int> UploadAudit(int auditAppId)
        {
            //get local audit
            var localAudit = await auditRepository.GetAuditById(auditAppId);
            return -1;
        }

        public async Task<GetSystemDataResponse> GetSystemData()
        {
            return await this.auditServiceRepository.GetSystemData();
        }
    }
}

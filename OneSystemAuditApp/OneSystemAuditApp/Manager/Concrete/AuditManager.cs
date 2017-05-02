using AuditAppPcl.Manager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities;
using AuditAppPcl.Repository.Contracts;

namespace AuditAppPcl.Manager.Concrete
{
    public class AuditManager : IAuditManager
    {
        public IAuditRepository auditRepository;

        public AuditManager()
        {
            auditRepository = UnityConfig.IAuditRepository;
        }

        public async Task InsertAudits(List<Audit> audits)
        {
            var convertedAudits = ConvertAuditIntoLocalAudit(audits);
            await auditRepository.InsertAudits(convertedAudits);
        }

        private List<Entities.Database.Audit> ConvertAuditIntoLocalAudit(List<Audit> audits)
        {
            List<Entities.Database.Audit> convertedAudits = new List<Entities.Database.Audit>();
            foreach (var audit in audits)
            {
                var convertedAudit = new Entities.Database.Audit();
                convertedAudit.AuditAppId = audit.AuditAppId;
                convertedAudit.ItemID = audit.ItemID;
                convertedAudit.ParentID = audit.ParentID;
                convertedAudit.ApplicantName = audit.ApplicantName;
                convertedAudit.CaseSubject = audit.CaseSubject;
                convertedAudit.CaseUID = audit.CaseUID;
                convertedAudit.BuildingLandAddress = audit.BuildingLandAddress;
                convertedAudit.BuildingNumber = audit.BuildingNumber;
                convertedAudit.InspectionType = audit.InspectionType;
                convertedAudit.InspectionStatus = audit.InspectionStatus;
                convertedAudit.Inspector = audit.Inspector;
                convertedAudit.BuildingOfficer = audit.BuildingOfficer;
                convertedAudit.OBOBuildingOfficer = audit.OBOBuildingOfficer;
                convertedAudit.InspectionDate = audit.InspectionDate;
                convertedAudit.InspectionNumber = audit.InspectionNumber;
                convertedAudit.Comment = audit.Comment;
                foreach (var attachment in audit.Attachements)
                {
                    var convertedAttachment = new Entities.Database.Attachement();
                    convertedAttachment.AuditAppAttachementId = attachment.AuditAppAttachementId;
                    convertedAttachment.ItemID = attachment.ItemID;
                    convertedAttachment.Comments = attachment.Comments;
                    convertedAttachment.Data = attachment.Data;
                    convertedAttachment.Name = attachment.Name;
                    convertedAttachment.Extention = attachment.Extention;
                    convertedAudit.Attachements.Add(convertedAttachment);
                }
                convertedAudit.Signature = audit.Signature;
                convertedAudit.SignatureIMG = audit.SignatureIMG;
                convertedAudit.HasAttachment = audit.HasAttachment;
                convertedAudit.IsSynced = audit.IsSynced;
                convertedAudit.SyncedDateTime = audit.SyncedDateTime;

                convertedAudits.Add(convertedAudit);
            }

            return convertedAudits;
        }
    }
}

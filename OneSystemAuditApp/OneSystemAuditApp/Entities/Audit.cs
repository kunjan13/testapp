using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities
{
    public class Audit
    {
        public int AuditAppId { get; set; }
        public string ItemID { get; set; } //[ItemID]
        public string ParentID { get; set; } //[ItemID] of case
        public string ApplicantName { get; set; } //[Company]
        public string CaseSubject { get; set; } //[CaseSubject]
        public string CaseUID { get; set; } //[UID]
        public string BuildingLandAddress { get; set; }//[Land_Subject]
        public string BuildingNumber { get; set; } //[LandNr]
        public string InspectionType { get; set; } //[Subject]
        public string InspectionStatus { get; set; } //[Status]
        public string Inspector { get; set; } //[Inspector]: Emploee
        public string BuildingOfficer { get; set; }//[BuildingOfficer]:master
        public string OBOBuildingOfficer { get; set; }//[OBOBuildingOfficer]:person
        public DateTime InspectionDate { get; set; } //[Date]
        public string InspectionNumber { get; set; } //[Number]: Number
        public string Comment { get; set; }//[Comment]
        public List<Attachement> Attachements { get; set; } //max 30 //img to attachements, comments to comments table
        public string Signature { get; set; }//comment table
        public byte[] SignatureIMG { get; set; } //Attachemnts

        public bool HasAttachment { get; set; }


        //App fields
        public bool IsSynced { get; set; }
        public DateTime SyncedDateTime { get; set; }

        public bool IsDownloaded { get; set; }
    }
}

using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace AuditAppPcl.Entities.Database
{
    public class Case
    {
        [PrimaryKey]
        [AutoIncrement]
        public int AuditAppCaseId { get; set; }

        public string ItemID { get; set; } //[ItemID] in cases, ParentId in audits
        public string ApplicantName { get; set; } //[Company]
        public string CaseSubject { get; set; } //[CaseSubject]
        public string CaseUID { get; set; } //[UID]
        public string BuildingLandAddress { get; set; }//[Land_Subject]
        public string BuildingNumber { get; set; } //[LandNr]
        [OneToMany]
        public List<Audit> Audits { get; set; }
    }
}

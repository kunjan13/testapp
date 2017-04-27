using AuditAppPcl.Entities.Database;
using System.Collections.Generic;

namespace AuditAppPcl.Entities.Response
{
    public class GetSystemDataResponse
    {
        public bool Success { get; set; }
        public List<string> Exception { get; set; }
        public List<string> InspectionTypes { get; set; }
        public List<string> InspectionStatuses { get; set; }
        public List<string> Inspectors { get; set; }
        public List<BuildingOfficer> BuildingOfficers { get; set; }
    }
}
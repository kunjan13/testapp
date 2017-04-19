using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Entities
{
    public class AuditViewModel: INotifyPropertyChanged
    {
        private int auditAppId;
        private string itemId;
        private string parentId;
        private string applicantName;
        private string caseSubject;
        private string caseUID;
        private string buildingLandAddress;
        private string buildingNumber;
        private string inspectionType;
        private string inspectionStatus;
        private string inspector;
        private string buildingOfficer;
        private string userName;
        private DateTime inspectionDate;
        private string comment;
        private string plot;
        private bool isDownloaded;
        private DateTime syncedDateTime;
        private bool isSynced;
        private string obdBuildingOfficer;
        private string inspectionNumber;
        private List<Attachement> attachments;
        private string signature;
        private byte[] signatureIMG;

        public int AuditAppId {
            get {
                return auditAppId;
            }
            set {
                auditAppId = value;
                OnPropertyChanged();
                //PropertyChanged(this, new PropertyChangedEventArgs("AuditAppId"));
            }
        }
        public string ItemID {
            get {
                return itemId;
            }
            set {
                this.itemId = value;
                OnPropertyChanged();
            }
        } //[ItemID]
        public string ParentID {
            get {
                return parentId;
            } set {
                this.parentId = value;
                OnPropertyChanged();
            }
        } //[ItemID] of case
        public string ApplicantName {
            get {
                return this.applicantName;
            } set {
                this.applicantName = value;
                OnPropertyChanged();
            }
        } //[Company]
        public string CaseSubject {
            get
            {
                return this.caseSubject;
            }
            set
            {
                this.caseSubject = value;
                OnPropertyChanged();
            }
        } //[CaseSubject]
        public string CaseUID {
            get
            {
                return this.caseUID;
            }
            set
            {
                this.caseUID = value;
                OnPropertyChanged();
            }
        } //[UID]
        public string BuildingLandAddress {
            get
            {
                return this.buildingLandAddress;
            }
            set
            {
                this.buildingLandAddress = value;
                OnPropertyChanged();
            }
        }//[Land_Subject]
        public string BuildingNumber {
            get
            {
                return this.buildingNumber;
            }
            set
            {
                this.buildingNumber = value;
                OnPropertyChanged();
            }
        } //[LandNr]
        public string InspectionType {
            get
            {
                return this.inspectionType;
            }
            set
            {
                this.inspectionType = value;
                OnPropertyChanged();
            }
        } //[Subject]
        public string InspectionStatus {
            get
            {
                return this.inspectionStatus;
            }
            set
            {
                this.inspectionStatus = value;
                OnPropertyChanged();
            }
        } //[Status]
        public string Inspector {
            get
            {
                return this.inspector;
            }
            set
            {
                this.inspector = value;
                OnPropertyChanged();
            }
        } //[Inspector]: Emploee
        public string BuildingOfficer {
            get {
                return buildingOfficer;
            }
            set {
                this.buildingOfficer = value;
                OnPropertyChanged();
                //PropertyChanged(this, new PropertyChangedEventArgs("BuildingOfficer"));
            }
        }//[BuildingOfficer]:master
        public string OBOBuildingOfficer {
            get
            {
                return this.obdBuildingOfficer;
            }
            set
            {
                this.obdBuildingOfficer = value;
                OnPropertyChanged();
            }
        }//[OBOBuildingOfficer]:person
        public DateTime InspectionDate {
            get
            {
                return this.inspectionDate;
            }
            set
            {
                this.inspectionDate = value;
                OnPropertyChanged();
            }
        } //[Date]
        public string InspectionNumber {
            get
            {
                return this.inspectionNumber;
            }
            set
            {
                this.inspectionNumber = value;
                OnPropertyChanged();
            }
        } //[Number]: Number
        public string Comment {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
                OnPropertyChanged();
            }
        }//[Comment]
        public List<Attachement> Attachements {
            get
            {
                return this.attachments;
            }
            set
            {
                this.attachments = value;
                OnPropertyChanged();
            }
        } //max 30 //img to attachements, comments to comments table
        public string Signature {
            get
            {
                return this.signature;
            }
            set
            {
                this.signature = value;
                OnPropertyChanged();
            }
        }//comment table
        public byte[] SignatureIMG {
            get
            {
                return this.signatureIMG;
            }
            set
            {
                this.signatureIMG = value;
                OnPropertyChanged();
            }
        } //Attachemnts
        public string Plot {
            get
            {
                return this.plot;
            }
            set
            {
                this.plot = value;
                OnPropertyChanged();
            }
        }
        public string UserName {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
                OnPropertyChanged();
            }
        }


        //App fields
        public bool IsSynced {
            get
            {
                return this.isSynced;
            }
            set
            {
                this.isSynced = value;
                OnPropertyChanged();
            }
        }
        public DateTime SyncedDateTime {
            get
            {
                return this.syncedDateTime;
            }
            set
            {
                this.syncedDateTime = value;
                OnPropertyChanged();
            }
        }

        public bool IsDownloaded {
            get
            {
                return this.isDownloaded;
            }
            set
            {
                this.isDownloaded = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }
    }
}

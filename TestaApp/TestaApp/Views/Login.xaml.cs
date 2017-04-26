using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Resources;
using AuditAppPcl.ViewModels;
using AuditAppPcl.Repository.Concrete;
using AuditAppPcl.Entities.Database;
using System.Collections.Generic;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ILogin login;
        AuditRepository auditRepository;
        public Login(ILogin login)
        {
            auditRepository = new AuditRepository();
            InsertInDB();
            this.login = login;
            var vm = new LoginViewModel();
            vm.Navigation = Navigation;
            this.BindingContext = vm;
            InitializeComponent();

            usernameEntry.Completed += (object sender, EventArgs e) =>
            {
                passwordEntry.Focus();
            };

            passwordEntry.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };

            versionlbl.Text = string.Format(AppResources.Version + " {0}", Settings.Settings.AppVersion);
            copyrightlbl.Text = AppResources.Copyright;
        }
        public async void InsertInDB()
        {
            var audit = GetAuditToUpdate();
            var result = await auditRepository.UpdateAudit(audit);
            //var result = await auditRepository.DeleteAudit(audit);
            if (result == true)
            {
                await DisplayAlert("Success", "Success", "OK");
            }
            else
            {
                await DisplayAlert("Fail", "Fail", "OK");
            }
            //var auditList = GetAudits();
            //await auditRepository.InsertAudits(auditList);
        }

        private Audit GetAuditToUpdate()
        {
            Audit audit = new Audit
            {
                AuditAppId = 2,
                UserName = "Kaushal",
                ItemID = "124",
                ParentID = "12",
                ApplicantName = "Test1",
                InspectionStatus = "Status1",
                Attachements = new List<Attachement> {
                        new Attachement
                        {
                            //ItemID = "123",
                            //AuditAppAttachementId = 4,
                            AuditAppId = 2,
                            Comment = "Test 2",
                            Data  = new byte[] { (byte)0xe0, 0x4f, (byte)0xd0, 0x20, (byte)0xea, 0x3a, 0x69, 0x10, (byte)0xa2, (byte)0xd8, 0x08, 0x00, 0x2b, 0x30, 0x30, (byte)0x9d },
                            Name = "TestTest",
                            Extention = ".jpg"
                        },
                        new Attachement
                        {
                            //ItemID = "123",
                            //AuditAppAttachementId = 5,
                            AuditAppId = 2,
                            Comment = "Test 3",
                            Data  = new byte[] { (byte)0xe0, 0x4f, (byte)0xd0, 0x20, (byte)0xea, 0x3a, 0x69, 0x10, (byte)0xa2, (byte)0xd8, 0x08, 0x00, 0x2b, 0x30, 0x30, (byte)0x9d },
                            Name = "TestTest",
                            Extention = ".jpg"
                        },
                        new Attachement
                        {
                            //ItemID = "123",
                            AuditAppAttachementId = 6,
                            AuditAppId = 2,
                            Comment = "Test 4",
                            Data  = new byte[] { (byte)0xe0, 0x4f, (byte)0xd0, 0x20, (byte)0xea, 0x3a, 0x69, 0x10, (byte)0xa2, (byte)0xd8, 0x08, 0x00, 0x2b, 0x30, 0x30, (byte)0x9d },
                            Name = "TestTest",
                            Extention = ".jpg"
                        },
                    },
                BuildingNumber = "",
                BuildingLandAddress = "",
                //AuditAppId = 11,
                BuildingOfficer = "",
                CaseSubject = "",
                CaseUID = "",
                Comment = "Change thai gau",
                InspectionDate = DateTime.Now,
                InspectionNumber = "",
                InspectionType = "",
                Inspector = "",
                IsSynced = true,
                OBOBuildingOfficer = "",
                Signature = "",
                SignatureIMG = null,
                SyncedDateTime = DateTime.Now
            };
            return audit;
        }
        private List<Audit> GetAudits()
        {
            List<Audit> audits = new List<Audit>
            {
                new Audit
                {
                    ItemID = "123",
                    ParentID = "12",
                    ApplicantName = "Test1",
                    InspectionStatus = "Status1",
                    Attachements = new List<Attachement> {
                        new Attachement
                        {
                            //ItemID = "123",
                            Comment = "",
                            Data  = new byte[] { (byte)0xe0, 0x4f, (byte)0xd0, 0x20, (byte)0xea, 0x3a, 0x69, 0x10, (byte)0xa2, (byte)0xd8, 0x08, 0x00, 0x2b, 0x30, 0x30, (byte)0x9d },
                            Name = "TestTest",
                            Extention = ".jpg"
                        }
                    },
                    BuildingNumber = "",
                    BuildingLandAddress = "",
                    //AuditAppId = 11,
                    BuildingOfficer = "",
                    CaseSubject = "",
                    CaseUID = "",
                    Comment = "Comment",
                    InspectionDate = DateTime.Now,
                    InspectionNumber = "",
                    InspectionType = "",
                    Inspector = "",
                    IsSynced = true,
                    OBOBuildingOfficer="",
                    Signature = "",
                    SignatureIMG = null,
                    SyncedDateTime = DateTime.Now
                },
                new Audit
                {
                    ItemID = "124",
                    ParentID = "12",
                    ApplicantName = "Test1",
                    InspectionStatus = "Status1",
                    Attachements = new List<Attachement>(),
                    BuildingNumber = "",
                    BuildingLandAddress = "",
                    //AuditAppId = 11,
                    BuildingOfficer = "",
                    CaseSubject = "",
                    CaseUID = "",
                    Comment = "Comment",
                    InspectionDate = DateTime.Now,
                    InspectionNumber = "",
                    InspectionType = "",
                    Inspector = "",
                    IsSynced = true,
                    OBOBuildingOfficer="",
                    Signature = "",
                    SignatureIMG = null,
                    SyncedDateTime = DateTime.Now
                },
                new Audit
                {
                    ItemID = "125",
                    ParentID = "12",
                    ApplicantName = "Test1",
                    InspectionStatus = "Status1",
                    Attachements = new List<Attachement>(),
                    BuildingNumber = "",
                    BuildingLandAddress = "",
                    //AuditAppId = 11,
                    BuildingOfficer = "",
                    CaseSubject = "",
                    CaseUID = "",
                    Comment = "Comment",
                    InspectionDate = DateTime.Now,
                    InspectionNumber = "",
                    InspectionType = "",
                    Inspector = "",
                    IsSynced = true,
                    OBOBuildingOfficer="",
                    Signature = "",
                    SignatureIMG = null,
                    SyncedDateTime = DateTime.Now
                }
            };
            return audits;
            //return Task.Run(async () => await auditServiceManager.GetAudits()).Result;
        }
    }
}

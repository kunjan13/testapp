using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAppPcl.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Concrete;
using AuditAppPcl.Entities.Database;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAudits : ContentPage
    {
        public ObservableCollection<AuditTemp> auditList = new ObservableCollection<AuditTemp>() {
            new AuditTemp { userId = "a", Description = "aaa" },
            new AuditTemp { userId = "b", Description = "bbb" }
        };
        public IAuditServiceManager auditServiceManager;
        AuditRepository auditRepository;


        public async void OpenCameraPage(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = true;
            //await Navigation.PushAsync(new PerformAudit(UnityConfig.IAuditInformation));
            await Navigation.PushAsync(new PerformAudit());

        }

        public async void OpenSignaturePage(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new signature());
        }


        public ListAudits()
        {
            auditRepository = new AuditRepository();
            this.auditServiceManager = UnityConfig.IAuditServiceManager;
            InitializeComponent();

            //listView.ItemTemplate = new DataTemplate(typeof(TextCell)); // has context actions defined
            //listView.ItemTemplate.SetBinding(TextCell.TextProperty, "userId");
            //listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "body");
            var listOfAudits = GetAudits();
            listView.ItemsSource = listOfAudits;
        }

        public async void View(object sender,EventArgs e)
        {
            //await Navigation.PushModalAsync(new PerformAudit());
            await Navigation.PushAsync(new PerformAudit());
        }

        private List<Entities.Database.Audit> GetAudits()
        {
            //List<Audit> audits = new List<Audit>
            //{
            //    new Audit
            //    {
            //        ItemID = "12346",
            //        ApplicantName = "Test1",
            //        InspectionStatus = "Status1"
            //    },
            //    new Audit
            //    {
            //        ItemID = "12345",
            //        ApplicantName = "Test1",
            //        InspectionStatus = "Status1"
            //    },
            //    new Audit
            //    {
            //        ItemID = "12344",
            //        ApplicantName = "Test1",
            //        InspectionStatus = "Status1"
            //    }
            //};
            return Task.Run(async () => await auditRepository.GetAudits()).Result;
            //var result = Task.Run(async () => await auditRepository.GetAuditById(1)).Result;
            //var listOfAudit = new List<Entities.Database.Audit>();
            //listOfAudit.Add(result);
            //return listOfAudit;
        }
    }
}

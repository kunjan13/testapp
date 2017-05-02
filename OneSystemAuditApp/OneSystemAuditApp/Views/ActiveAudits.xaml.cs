using AuditAppPcl.Manager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditAppPcl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActiveAudits : ContentPage
    {
        IAuditServiceManager auditServiceManager;
        IAuditManager auditManager;
        public ActiveAudits()
        {
            auditServiceManager = UnityConfig.IAuditServiceManager;
            auditManager = UnityConfig.IAuditManager;
            InitializeComponent();
            //DownloadNewAuditAndSave();
            var activeAudits  = GetActiveAudits();
        }

        private void DownloadNewAuditAndSave()
        {
            var listOfAudits = auditServiceManager.GetAudits().Result;
            if(listOfAudits != null && listOfAudits.Count > 0)
            {
                auditManager.InsertAudits(listOfAudits);
            }
        }

        private List<Entities.Database.Audit> GetActiveAudits()
        {
            var activeAudits = auditManager.GetActiveAudits().Result;
            return activeAudits;
        }
    }
}

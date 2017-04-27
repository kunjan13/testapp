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
        public ListAudits()
        {
            this.auditServiceManager = UnityConfig.IAuditServiceManager;
            InitializeComponent();

            //listView.ItemTemplate = new DataTemplate(typeof(TextCell)); // has context actions defined
            //listView.ItemTemplate.SetBinding(TextCell.TextProperty, "userId");
            //listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "body");
            listView.ItemsSource = GetAudits();
        }

        private List<Audit> GetAudits()
        {
            return Task.Run(async () => await auditServiceManager.GetAudits()).Result;
        }
    }
}

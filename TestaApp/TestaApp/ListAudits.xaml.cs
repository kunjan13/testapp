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
        public ObservableCollection<Audit> auditList = new ObservableCollection<Audit>() {
            new Audit { userId = "a", Description = "aaa" },
            new Audit { userId = "b", Description = "bbb" }
        };
        public IAuditServiceManager auditServiceManager;
        public ListAudits(IAuditServiceManager auditServiceManager)
        {
            this.auditServiceManager = auditServiceManager;
            InitializeComponent();

            listView.ItemTemplate = new DataTemplate(typeof(TextCell)); // has context actions defined
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "userId");
            //listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Description");
            listView.ItemsSource = GetAudits();
        }

        private List<Audit> GetAudits()
        {
            return auditServiceManager.GetAudits().Result;
        }
    }
}

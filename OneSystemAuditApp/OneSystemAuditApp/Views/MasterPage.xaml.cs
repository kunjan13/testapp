using AuditAppPcl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView MenuListView { get { return menuListView; } }
        public MasterPage()
        {
            InitializeComponent();
            var menuItems = new List<MenuItems>();
            menuItems.Add(new MenuItems
            {
                Name = "My Audits",
                TargetType = typeof(ListAudits)
            });
            menuItems.Add(new MenuItems
            {
                Name = "Active Audits",
                TargetType = typeof(ListAudits)
            });
            menuItems.Add(new MenuItems
            {
                Name = "Cases",
                TargetType = typeof(ListAudits)
            });
            menuItems.Add(new MenuItems
            {
                Name = "Settings",
                TargetType = typeof(ListAudits)
            });
            menuItems.Add(new MenuItems
            {
                Name = "Log Out/Clean",
                TargetType = typeof(ListAudits)
            });

            menuListView.ItemsSource = menuItems;
        }
    }
}

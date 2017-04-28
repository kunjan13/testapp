using AuditAppPcl.Entities;
using AuditAppPcl.Resources;
using AuditAppPcl.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView MenuListView { get { return menuListView; } }
        private List<MenuItems> menuItems = new List<MenuItems>();
        public List<MenuItems> MenuItemsList { get { return menuItems; } }

        public MasterPage()
        {
            this.BindingContext = new ObservableCollection<MenuItems>();
            InitializeComponent();
            menuItems = new List<MenuItems>();
            menuItems.Add(new MenuItems
            {
                Name = AppResources.Menu_MyAudits,
                IsSelected = true,
                TargetType = typeof(ListAudits)
            });
            menuItems.Add(new MenuItems
            {
                Name = AppResources.Menu_ActiveAudits,
                TargetType = typeof(ActiveAudits)
            });
            menuItems.Add(new MenuItems
            {
                Name = AppResources.Menu_Cases,
                TargetType = typeof(Cases)
            });
            menuItems.Add(new MenuItems
            {
                Name = AppResources.Menu_Settings,
                TargetType = typeof(Views.Settings)
            });
            menuItems.Add(new MenuItems
            {
                Name = AppResources.Menu_Logout_Clean,
                TargetType = typeof(Logout)
            });

            menuListView.ItemsSource = menuItems;
        }
    }
}

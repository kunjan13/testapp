using AuditAppPcl.Entities;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditAppPcl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.MenuListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItems;
            if (item != null)
            {
                masterPage.MenuListView.SelectedItem = null;
                foreach (var menuitem in masterPage.MenuItemsList)
                {
                    menuitem.IsSelected = false;
                }
                item.IsSelected = true;
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                IsPresented = false;
            }
        }
    }
}

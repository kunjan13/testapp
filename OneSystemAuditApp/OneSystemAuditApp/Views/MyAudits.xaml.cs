using AuditAppPcl.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditAppPcl.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAudits : ContentPage
    {
        public MyAudits()
        {
            var myAuditsViewModel = new ListAuditsViewModel();
            this.BindingContext = myAuditsViewModel;
            

            InitializeComponent();
        }

        async void OnSortAuditDateAction(object sender, EventArgs e)
        {
            
            var action = await DisplayActionSheet("Select Sort Order for Audit Date", "Cancel", null, "Sort Ascending", "Sort Descending");
            if (action == "Sort Ascending")
            {
                //await DisplayAlert("Sort");
            }
        }
        private bool isRowEven = true;
        private void Cell_OnAppearing(object sender, EventArgs e)
        {
            if (this.isRowEven)
            {
                var viewCell = (ViewCell)sender;
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("#e5e3e4");
                }
            }

            this.isRowEven = !this.isRowEven;
        }

    }
}

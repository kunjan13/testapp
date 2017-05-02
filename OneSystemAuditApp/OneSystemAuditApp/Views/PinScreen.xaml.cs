using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Resources;
using AuditAppPcl.ViewModels;
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
    public partial class PinScreen : ContentPage
    {
        public ILogin login;
        string Pin = string.Empty;
        public PinScreen()
        {
            this.login = UnityConfig.ILogin;
            var vm = new _4DigitPinViewModel();
            vm.Navigation = Navigation;
            this.BindingContext = vm;
            InitializeComponent();
            //vm.SubmitCommand.Execute(null);
            versionlbl.Text = string.Format(AppResources.Version + " {0}", Settings.Settings.AppVersion);
            copyrightlbl.Text = AppResources.Copyright;
            submitButton.IsEnabled = false;
        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            bool isValid = true;
            int n;
            if (e.NewTextValue.Length > 1)
            {
                entry.Text = entry.Text.Remove(1);
                return;
            }
            if (!int.TryParse(e.NewTextValue, out n))
            {
                entry.Text = "";
                isValid = false;
            }

            CheckPinValidation();
            //pin2.Focus();
            if (isValid)
            {
                SetFocusOn();
            }
        }

        void SetFocusOn()
        {
            if (pin1.Text == null || pin1.Text == "")
            {
                pin1.Focus();
                return;
            }
            if (pin2.Text == null || pin2.Text == "")
            {
                pin2.Focus();
                return;
            }
            if (pin3.Text == null || pin3.Text == "")
            {
                pin3.Focus();
                return;
            }
            if (pin4.Text == null || pin4.Text == "")
            {
                pin4.Focus();
                return;
            }
        }

        void CheckPinValidation()
        {
            if (pin1.Text != null && pin2.Text != null && pin3.Text != null && pin4.Text != null
               && pin1.Text != "" && pin2.Text != "" && pin3.Text != "" && pin4.Text != "")
            {
                submitButton.IsEnabled = true;
            }
            else
            {
                submitButton.IsEnabled = false;
            }
        }
    }
}

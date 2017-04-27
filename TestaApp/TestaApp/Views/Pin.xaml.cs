using AuditAppPcl.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AuditAppPcl
{
    public partial class Pin : ContentPage
    {
        public Pin()
        {
            InitializeComponent();
            versionlbl.Text = string.Format(AppResources.Version + " {0}", Settings.Settings.AppVersion);
            copyrightlbl.Text = AppResources.Copyright;

            //Entry2.NextView = Entry3;
            //Entry2.ReturnButton = ReturnButtonType.Next;

            //Entry3.NextView = Entry1;
            //Entry3.ReturnButton = ReturnButtonType.Next;
        }

        private EventHandler<TextChangedEventArgs> Pin1Change()
        {
            throw new NotImplementedException();
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
            if(!int.TryParse(e.NewTextValue,out n))
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

        async void Submit_Clicked(object sender,EventArgs e)
        {
            var pin = pin1.Text + pin2.Text + pin3.Text + pin4.Text;
            if(pin == "1234")
            {
                messageLabel.IsVisible = false;
                var townName = "Town Name";
                await Navigation.PushModalAsync(new Login(UnityConfig.ILogin, townName));
            }
            else
            {
                messageLabel.IsVisible = true;
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
            if(pin1.Text != null && pin2.Text != null && pin3.Text != null && pin4.Text != null 
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

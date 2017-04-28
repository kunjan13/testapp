using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AuditAppPcl.Views;

namespace AuditAppPcl.ViewModels
{
    public class _4DigitPinViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { protected set; get; }

        private string pin1;
        private string pin2;
        private string pin3;
        private string pin4;

        private string pin;

        private string message;
        private bool isError = false;

        public _4DigitPinViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public string Pin1
        {
            get
            {
                return pin1;
            }
            set
            {
                pin1 = value;
                OnPropertyChanged("Pin1");
            }
        }

        public string Pin2
        {
            get
            {
                return pin2;
            }
            set
            {
                pin2 = value;
                OnPropertyChanged("Pin2");
            }
        }

        public string Pin3
        {
            get
            {
                return pin3;
            }
            set
            {
                pin3 = value;
                OnPropertyChanged("Pin3");
            }
        }

        public string Pin4
        {
            get
            {
                return pin4;
            }
            set
            {
                pin4 = value;
                OnPropertyChanged("Pin4");
            }
        }

        public string Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
                OnPropertyChanged("Pin");
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public bool IsError
        {
            get
            {
                return isError;
            }

            set
            {
                isError = value;
                OnPropertyChanged("IsError");
            }
        }

        public async void OnSubmit()
        {
            var login = UnityConfig.ILogin;
            this.IsBusy = true;
            Pin = Pin1 + Pin2 + Pin3 + Pin4;
            var pinResponse = login.GetServicePath(Pin);
            if (pinResponse.Sucsess)
            {
                Message = string.Empty;
                IsError = false;
                await Navigation.PushModalAsync(new Login());
            }
            else
            {
                IsError = true;
                Message = pinResponse.Exception.FirstOrDefault().ToString();
            }
            this.IsBusy = false;
        }
    }
}

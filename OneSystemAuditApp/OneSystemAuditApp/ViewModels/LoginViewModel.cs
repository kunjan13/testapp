using AuditAppPcl.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuditAppPcl.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { protected set; get; }

        private string username;

        private string password;

        private string message;


        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                OnPropertyChanged("Password");
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

        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public async void OnSubmit()
        {
            var login = UnityConfig.ILogin;
            this.IsBusy = true;
            var loginResponse = login.LoginUser(Username, Password);
            if (loginResponse.Success)
            {
                Message = string.Empty;
                App.IsUserLoggedIn = true;
                await Navigation.PushModalAsync(new MainPage());
                //App.Current.MainPage = new MainPage();
            }
            else
            {
                Message = loginResponse.ErrorMessage;
                Password = string.Empty;
            }
            this.IsBusy = false;
        }
    }
}

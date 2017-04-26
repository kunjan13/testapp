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
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion

        public ICommand SubmitCommand { protected set; get; }

        private string username;

        private string password;

        private string message;

        private bool isBusy;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
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
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public INavigation Navigation { get; set; }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Message"));
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
            if (loginResponse.Status == Entities.Response.LoginResponse.LoginStatus.success)
            {
                Message = string.Empty;
                App.IsUserLoggedIn = true;                
                await Navigation.PushModalAsync(new MainPage());
                //var mainPage = new NavigationPage(new MainPage());
                //NavigationPage.SetHasNavigationBar(mainPage, false);
                //await mainPage.PopAsync();
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

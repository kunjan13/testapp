using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuditAppPcl.Entities
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion

        public ICommand SubmitCommand { protected set; get; }

        private string username;

        private string password;

        private string Message { get; set; }

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

        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            var login = UnityConfig.ILogin;
            var loginResponse = login.LoginUser(Username, Password);
            if (loginResponse.Status == Response.LoginResponse.LoginStatus.success)
            {
                Message = string.Empty;
                App.IsUserLoggedIn = true;
                Navigation.PushAsync(new ListAudits(UnityConfig.IAuditServiceManager));
            }
            else
            {
                Message = loginResponse.ErrorMessage;
                Password = string.Empty;
            }
        }
    }
}

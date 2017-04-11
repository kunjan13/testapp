using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AuditAppPcl.Manager.Contracts;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ILogin login;
        public Login(ILogin login)
        {
            this.login = login;
            InitializeComponent();
        }

        public async void OnLogin(object sender, EventArgs e)
        {
            var user = login.LoginUser(usernameEntry.Text, passwordEntry.Text);
            if (string.IsNullOrEmpty(user.ErrorMessage))
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new ListAudits(UnityConfig.IAuditServiceManager), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = user.ErrorMessage;
                passwordEntry.Text = string.Empty;
            }
        }
    }
}

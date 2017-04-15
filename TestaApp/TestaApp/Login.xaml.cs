﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Entities;

namespace AuditAppPcl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ILogin login;
        public Login(ILogin login)
        {
            this.login = login;
            var vm = new LoginViewModel();
            vm.Navigation = Navigation;
            this.BindingContext = vm;
            InitializeComponent();

            usernameEntry.Completed += (object sender, EventArgs e) =>
            {
                passwordEntry.Focus();
            };

            passwordEntry.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
    }
}

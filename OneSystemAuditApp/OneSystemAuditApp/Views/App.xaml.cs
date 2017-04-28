﻿using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AuditAppPcl
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public static string TownName { get; set; }
        public static string LoginToken { get; set; }
        public static string Username { get; set; }

        public App()
        {
            InitializeComponent();
            UnityConfig.Configure();

            if (!IsUserLoggedIn)
            {
                //MainPage = new AuditAppPcl.Login();
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new MainPage();
                //MainPage = new NavigationPage(new AuditAppPcl.ListAudits());
            }
        }

        public void NavigateToMainPage()
        {
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

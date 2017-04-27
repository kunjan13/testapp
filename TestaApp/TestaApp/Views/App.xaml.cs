﻿using AuditAppPcl.Entities.Database;
using AuditAppPcl.Manager.Contracts;
using AuditAppPcl.Repository.Concrete;
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
        

        public App()
        {
            InitializeComponent();
            UnityConfig.Configure();
            if (!IsUserLoggedIn)
            {
                MainPage = new AuditAppPcl.Pin();
                //MainPage = new AuditAppPcl.Login(UnityConfig.ILogin);
                //MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new AuditAppPcl.ListAudits());
            }
        }

       

        public void NavigateToMainPage()
        {
            MainPage = new MainPage();
        }

        public void OpenPerformAuditPage()
        {
            //MainPage = new NavigationPage(new AuditAppPcl.PerformAudit());
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

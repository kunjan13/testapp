﻿using Microsoft.Practices.Unity;
using AuditAppPcl.Repository.Contracts;
using AuditAppPcl.Repository.Concrete;
using ManagerContract = AuditAppPcl.Manager.Contracts;
using ManagerConcrete = AuditAppPcl.Manager.Concrete;
using RepositoryContract = AuditAppPcl.Repository.Contracts;
using RepositoryConcrete = AuditAppPcl.Repository.Concrete;
using Microsoft.Practices.ServiceLocation;
using AuditAppPcl.RestClient;

namespace AuditAppPcl
{
    public static class UnityConfig
    {
        private static readonly UnityContainer container = new UnityContainer();

        public static Login Login
        {
            get
            {
                return container.Resolve<Login>();
            }
        }
        public static ManagerContract.ILogin ILogin
        {
            get
            {
                return container.Resolve<ManagerContract.ILogin>();
            }
        }

        public static ManagerContract.IAuditServiceManager IAuditServiceManager
        {
            get
            {
                return container.Resolve<ManagerContract.IAuditServiceManager>();
            }
        }

        public static ManagerContract.ICaseServiceManager ICaseServiceManager
        {
            get
            {
                return container.Resolve<ManagerContract.ICaseServiceManager>();
            }
        }

        public static ManagerContract.IAuditManager IAuditManager
        {
            get
            {
                return container.Resolve<ManagerContract.IAuditManager>();
            }
        }

        public static RepositoryContract.IAuditRepository IAuditRepository
        {
            get
            {
                return container.Resolve<RepositoryContract.IAuditRepository>();
            }
        }

        public static void Configure()
        {
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IAuditRepository, AuditRepository>();
            container.RegisterType<IAuditServiceRepository, AuditServiceRepository>();
            container.RegisterType<ICaseServiceRepository, CaseServiceRepository>();
            container.RegisterType<ManagerContract.ILogin, ManagerConcrete.Login>();
            container.RegisterType<ManagerContract.IAuditServiceManager, ManagerConcrete.AuditServiceManager>();
            container.RegisterType<ManagerContract.ICaseServiceManager, ManagerConcrete.CaseServiceManager>();
            container.RegisterType<RepositoryContract.IAuditRepository, RepositoryConcrete.AuditRepository>();
            container.RegisterType<ManagerContract.IAuditManager, ManagerConcrete.AuditManager>();
            container.RegisterType<IRestClient, AuditAppPcl.RestClient.RestClient>();
            container.RegisterType<Login>(new ContainerControlledLifetimeManager());

            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

        }

    }
}


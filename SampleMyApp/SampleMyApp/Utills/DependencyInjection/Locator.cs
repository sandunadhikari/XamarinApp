using Autofac;
using SampleMyApp.Services.NavigationServices;
using SampleMyApp.Services.RepositoryServices;
using SampleMyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMyApp.Utills.DependencyInjection
{
    public class Locator
    {
        private IContainer _container;
        private ContainerBuilder _containerBuilder;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }
        public Locator()
        {
            _containerBuilder = new ContainerBuilder();

            #region Locator ViewModel Registration
            _containerBuilder.RegisterType<LoginViewModel>();
            _containerBuilder.RegisterType<ListPageViewModel>();
            _containerBuilder.RegisterType<InsertPageViewModel>();
            _containerBuilder.RegisterType<UpdatePageViewModel>();
            #endregion

            #region Locator Service Registration 
            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            _containerBuilder.RegisterType<RepositoryServices>().As<IRepositoryServices>().SingleInstance();
            #endregion
        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
        public void Build()
        {
            _container = _containerBuilder.Build();
        }
    }
}

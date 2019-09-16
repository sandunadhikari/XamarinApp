using SampleMyApp.Services.NavigationServices;
using SampleMyApp.Services.RepositoryServices;
using SampleMyApp.Utills.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMyApp.Helpers
{
    public class BaseViewModel:BaseAbstractViewModel
    {
        protected readonly INavigationService NavigationService;
        protected readonly IRepositoryServices RepositoryService;


        public BaseViewModel()
        {
            NavigationService = Locator.Instance.Resolve<INavigationService>();
            RepositoryService = Locator.Instance.Resolve<IRepositoryServices>();
        }
    }
}

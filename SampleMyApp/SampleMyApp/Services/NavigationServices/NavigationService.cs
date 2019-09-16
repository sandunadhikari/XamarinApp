using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using SampleMyApp.Helpers;
using SampleMyApp.Helpers.CustomViews;
using SampleMyApp.Utills.DependencyInjection;
using SampleMyApp.ViewModels;
using SampleMyApp.Views;
using Xamarin.Forms;

namespace SampleMyApp.Services.NavigationServices
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        private void CreatePageViewModelMappings()
        {
            #region NavigationService MapViewModelToView  
            _mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
            _mappings.Add(typeof(ListPageViewModel), typeof(ListPage));
            _mappings.Add(typeof(InsertPageViewModel), typeof(InsertPage));
            _mappings.Add(typeof(UpdatePageViewModel), typeof(UpdatePage));
            #endregion
        }
        public async Task InitializeAsync()
        {
            await NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseAbstractViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseAbstractViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }
        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (parameter is Boolean)
            {
                if ((Boolean)parameter)
                {
                    await NavigateToPage(page);
                }

            }
            else
            {
                if (page is LoginPage)
                {
                    SetMainPage(page);
                }
                else
                {
                    await NavigateToPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).Initialize(parameter);
        }
        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            Page page = null;

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            try
            {
                page = Activator.CreateInstance(pageType) as Page;
                BaseViewModel viewModel = Locator.Instance.Resolve(viewModelType) as BaseViewModel;
                page.BindingContext = viewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return page;
        }
        private async Task NavigateToPage(Page page)
        {
            if (Application.Current.MainPage is CustomNavigationView navigationPage)
            {
                //navigationPage.textColor = Color.FromHex("#23ae6b");
                await navigationPage.PushAsync(page);
            }
            else
            {
                SetMainPage(page);
            }
        }

        private void SetMainPage(Page page)
        {

            Application.Current.MainPage = new CustomNavigationView(page);
            Debug.WriteLine("SetMainPage");
            /*{
                textColor = Color.FromHex("#23ae6b")
            };*/
        }
        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }
    }
}

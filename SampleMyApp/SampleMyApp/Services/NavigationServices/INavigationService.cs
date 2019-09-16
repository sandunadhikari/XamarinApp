using SampleMyApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleMyApp.Services.NavigationServices
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseAbstractViewModel;
        //Task ReloadNavigateAsync<TViewModel>() where TViewModel : BaseAbstractViewModel;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseAbstractViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateToAsync(Type viewModelType, object parameter);

        //Task NavigateModalAsync<TViewModel>(bool animated = true) where TViewModel : BaseAbstractViewModel;

        //Task NavigateModalAsync<TViewModel>(object parameter, bool animated = true) where TViewModel : BaseAbstractViewModel;

        //Task NavigateBackAsync();

        //Task RemoveLastFromBackStackAsync();

        //Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : BaseAbstractViewModel;

        //Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : BaseAbstractViewModel;

        //Task NavigateToPopModalAsync();

        //Task ExecuteCancelModalCommand();
    }
}

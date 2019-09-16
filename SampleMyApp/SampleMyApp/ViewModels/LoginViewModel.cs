using SampleMyApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;

        public ICommand NextCommand { get; private set; }

        public string Username
        {
            get => username;
            set
            {
                if (value != null)
                {
                    username = value;
                }
            }
        }

        public LoginViewModel()
        {
            NextCommand = new Command(async () => await ListPageLoad());
        }

        private async Task ListPageLoad()
        {
            if (username != null)
            {
                await NavigationService.NavigateToAsync<ListPageViewModel>(username);
            }
        }
    }
}

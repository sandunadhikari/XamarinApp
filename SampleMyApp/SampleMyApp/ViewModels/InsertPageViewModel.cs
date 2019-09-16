using SampleMyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class InsertPageViewModel: ItemViewModel
    {
        public ICommand AddItemCommand { get;private set; }

        public InsertPageViewModel()
        {
            _item = new Item();
            AddItemCommand = new Command(async () => await InsertData());
        }

        private async Task InsertData()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Item", "Do you want to save Item details?", "OK", "Cancel");
            if (isUserAccept)
            {
                RepositoryService.InserItem(_item);
                await NavigationService.NavigateToAsync<ListPageViewModel>(Welcome);
            }
        }
    }
}

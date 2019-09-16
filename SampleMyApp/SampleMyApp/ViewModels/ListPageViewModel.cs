using SampleMyApp.Helpers;
using SampleMyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class ListPageViewModel : ItemViewModel
    {
        private Item selectedItem;

        public ICommand AddCommand { get; private set; }

        public ListPageViewModel()
        {
            AddCommand = new Command(async () => await GOInsertpage());
        }

        private async Task GOInsertpage()
        {
            await NavigationService.NavigateToAsync<InsertPageViewModel>();
        }
        public override Task Initialize(object navigationData)
        {
            if (navigationData != null)
            {
                Welcome = navigationData as string;

            }
            FetchItems();
            return base.Initialize(navigationData);
        }
        void FetchItems()
        {
            ItemList = RepositoryService.GetItems();
        }

        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != null)
                {
                    selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                    ShowVehicleDetails(value);
                }
            }
        }

        private async Task ShowVehicleDetails(Item value)
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("ActionSheet: select to?", "Cancel", null, "Delete", "Update");
            
            if (action == "Delete")
            {
                RepositoryService.DeleteItem(value.ItemId);
                FetchItems();
            }
            else if (action == "Update")
            {
                await NavigationService.NavigateToAsync<UpdatePageViewModel>(value);

            }
        }
    }

}

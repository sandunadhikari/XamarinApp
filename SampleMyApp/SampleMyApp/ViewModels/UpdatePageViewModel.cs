using SampleMyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class UpdatePageViewModel: ItemViewModel
    {
        public ICommand UpdateItemCommand { get; private set; }

        public UpdatePageViewModel()
        {
            _item = new Item();
            UpdateItemCommand = new Command(async () => await UpdateData());

            //_item = RepositoryService.GetItem(1);
        }

        private async Task UpdateData()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Item Details", "Update Contact Details", "OK", "Cancel");
            if (isUserAccept)
            {
                RepositoryService.UpdateItem(_item);
                await NavigationService.NavigateToAsync<ListPageViewModel>(Welcome);

            }
        }
        public override Task Initialize(object navigationData)
        {
            if (navigationData != null)
            {
                 _item = navigationData as Item;
                Subject = _item.Subject;
                Date = _item.Date;
                Description = _item.Description;


            }

            return base.Initialize(navigationData);
        }
    }
}

using SampleMyApp.Helpers;
using SampleMyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SampleMyApp.ViewModels
{
    public class ItemViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Item _item;
        public List<Item> _itemList;
        private string welcome;

        public string Subject
        {
            get => _item.Subject;
            set
            {
                if (value != null)
                {
                    _item.Subject = value;
                    NotifyPropertyChanged("Subject");
                }
            }
        }
        public DateTime Date
        {
            get => _item.Date;
            set
            {
                if (value != null)
                {
                    _item.Date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }
        public string Description
        {
            get => _item.Description;
            set
            {
                if (value != null)
                {
                    _item.Description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }
        public List<Item> ItemList
        {
            get => _itemList;
            set
            {
                _itemList = value;
                NotifyPropertyChanged("ItemList");
            }
        }
        public string Welcome
        {
            get => welcome;
            set
            {
                if (value != null)
                {
                    welcome = value;
                    NotifyPropertyChanged("Welcome");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

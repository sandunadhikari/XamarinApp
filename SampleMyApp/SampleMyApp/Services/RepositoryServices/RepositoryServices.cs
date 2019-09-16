using SampleMyApp.Helpers;
using SampleMyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMyApp.Services.RepositoryServices
{
    public class RepositoryServices : IRepositoryServices
    {
        SQLiteHelper _sqliteHelper;
        public RepositoryServices()
        {
            _sqliteHelper = new SQLiteHelper();
        }
        public void DeleteItem(int itemID)
        {
            _sqliteHelper.DeleteItem(itemID);
        }

        public Item GetItem(int itemID)
        {
            return _sqliteHelper.GetItem(itemID);
        }

        public List<Item> GetItems()
        {
            return _sqliteHelper.GetItems();
        }

        public void InserItem(Item item)
        {
            _sqliteHelper.InserItem(item);
        }

        public void UpdateItem(Item item)
        {
            _sqliteHelper.UpdateItem(item);
        }
    }
}

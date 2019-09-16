using SampleMyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMyApp.Services.RepositoryServices
{
    public interface IRepositoryServices
    {
        //get all data
        List<Item> GetItems();
        //get specific data
        Item GetItem(int itemID);
        //delete item
        void DeleteItem(int itemID);
        //insert item
        void InserItem(Item item);
        //update data
        void UpdateItem(Item item);
    }
}

using SampleMyApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SampleMyApp.Helpers
{
    public class SQLiteHelper
    {
        static SQLiteConnection db;
        private string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private const string DbFileName = "XamarinSQLite.db";
        public SQLiteHelper()
        {
            string dbPath = Path.Combine(documentsPath, DbFileName);
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Item>();
        }

        //Insert new record  
        public void InserItem(Item item)
        {

            db.Insert(item);

        }
        //Update record
        public void UpdateItem(Item item)
        {

            db.Update(item);

        }

        //Delete  
        public void DeleteItem(int id)
        {
            db.Delete<Item>(id);
        }

        //Read All Items  
        public List<Item> GetItems()
        {
            return (from data in db.Table<Item>() select data).ToList();
        }


        //Read Item  
        public Item GetItem(int itemId)
        {
            return db.Table<Item>().FirstOrDefault(i => i.ItemId == itemId);
        }
    }
}

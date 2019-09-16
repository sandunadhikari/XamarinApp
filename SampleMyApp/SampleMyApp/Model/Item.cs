using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMyApp.Model
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }


    }
}

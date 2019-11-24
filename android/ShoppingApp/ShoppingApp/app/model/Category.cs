using System;
using SQLite;

namespace ShoppingApp.app.model
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

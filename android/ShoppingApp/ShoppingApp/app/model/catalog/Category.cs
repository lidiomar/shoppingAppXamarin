using System;
using SQLite;

namespace ShoppingApp.app.model.catalog
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

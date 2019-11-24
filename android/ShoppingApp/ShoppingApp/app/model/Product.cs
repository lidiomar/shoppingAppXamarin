using Newtonsoft.Json;
using SQLite;

namespace ShoppingApp.app.model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }
        [JsonProperty(PropertyName = "category_id")]
        public string Category { get; set; }
        public bool Favorite { get; set; }
    }
}

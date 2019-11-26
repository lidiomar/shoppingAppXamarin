using Newtonsoft.Json;
using SQLite;

namespace ShoppingApp.app.model.catalog
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }
        [Ignore]
        public float SumPrice { get; set;}
        [Ignore]
        public int Quantity { get; set; }
        [Ignore]
        public float DiscountValue { get; set; }
        [Ignore]
        public float DiscountPercent { get; set; }
        [JsonProperty(PropertyName = "category_id")]
        public string Category { get; set; }
        public bool Favorite { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;

namespace ShoppingApp.app.model
{
    public class Sale
    {
        [JsonProperty(PropertyName = "category_id")]
        public string Category { get; set; }
        public string Name { get; set; }
        [TextBlob("policies")]
        public List<Policie> Policies { get; set; }
    }
}

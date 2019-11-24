using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShoppingApp.app.model
{
    public class Sale
    {
        [JsonProperty(PropertyName = "category_id")]
        public string Category { get; set; }
        public string Name { get; set; }
        public List<Policie> Policies { get; set; }
    }
}

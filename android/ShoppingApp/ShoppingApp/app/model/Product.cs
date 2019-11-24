﻿using Newtonsoft.Json;

namespace ShoppingApp.app.model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public string Category { get; set; }    
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public interface CatalogDataSource
    {
        Task GetCategoriesAsync();
    }
}

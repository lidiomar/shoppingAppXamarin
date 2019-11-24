using System;
using System.Collections.Generic;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public interface ICatalogView
    {
        void LoadData(List<Categorie> categories, List<Sale> sales, List<Product> products);
    }
}

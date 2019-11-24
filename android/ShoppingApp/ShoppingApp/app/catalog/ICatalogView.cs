using System;
using System.Collections.Generic;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public interface ICatalogView
    {
        void LoadData(List<Category> categories, List<Object> preparedList);
    }
}

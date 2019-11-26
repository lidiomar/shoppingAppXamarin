using System;
using System.Collections.Generic;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.catalog.view
{
    public interface ICatalogView
    {
        void LoadData(List<Category> categories, List<Object> preparedList, Dictionary<string, Sale> salesDict);
        void UpdateButtonBuyValue(float value);
    }
}

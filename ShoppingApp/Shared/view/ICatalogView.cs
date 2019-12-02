using System;
using System.Collections.Generic;
using ShoppingApp.app.model.catalog;

namespace Shared.view
{
    public interface ICatalogView
    {
        void LoadData(List<Category> categories, List<Object> preparedList, Dictionary<string, Sale> salesDict);
        void LoadFiteredData(List<Object> preparedList);
        void UpdateButtonBuyValue(float value);
        void IsLoading();
        void ShowErrorMessage();
        void ShowMain();
    }
}

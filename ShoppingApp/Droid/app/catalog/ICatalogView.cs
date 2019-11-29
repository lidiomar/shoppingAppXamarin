using System;
using System.Collections.Generic;
using ShoppingApp.app.model.catalog;

namespace Droid.app.catalog
{
    public interface ICatalogView
    {
        void LoadData(List<Category> categories, Android.Runtime.JavaList<Object> preparedList, Dictionary<string, Sale> salesDict);
        void LoadFiteredData(Android.Runtime.JavaList<Object> preparedList);
        void UpdateButtonBuyValue(float value);
        void IsLoading();
        void ShowErrorMessage();
    }
}

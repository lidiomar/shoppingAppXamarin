using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.catalog.view;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog.viewmodel
{
    public class CatalogViewModel
    {
        protected CatalogRepository catalogRepository = new CatalogRepository();
        protected ICatalogView view;
        
        public CatalogViewModel(ICatalogView view)
        {
            this.view = view;
        }

        public async void GetCategories()
        {
            var getCategories = catalogRepository.GetCategoriesAsync();
            var getProducts = catalogRepository.GetProductsAsync();
            var getSales = catalogRepository.GetSalesAsync();

            await Task.WhenAll(getCategories, getProducts, getSales).ContinueWith(result =>
            {

                if (result.IsCompleted && result.Status == TaskStatus.RanToCompletion)
                {
                    List<Object> preparedList = GetPreparedList(catalogRepository.products, catalogRepository.sales);
                    this.view.LoadData(catalogRepository.categories, preparedList);
                }
                else if (result.IsFaulted)
                {
                    // If any error occurred exception throws.
                }
                else if (result.IsCanceled)
                {
                    // Task cancelled
                }
            }, TaskScheduler.FromCurrentSynchronizationContext()).ConfigureAwait(false);
        }

        private List<Object> GetPreparedList(List<Product> Products, List<Sale> Sales)
        {
            List<Object> preparedList = new List<Object>();
            string currentCategory = "";
            foreach (Product product in Products)
            {
                if (currentCategory != product.Category)
                {
                    currentCategory = product.Category;
                    Sale sale = GetSaleObject(Sales, currentCategory);
                    preparedList.Add(sale);
                }
                preparedList.Add(product);
            }
            return preparedList;
        }

        private Sale GetSaleObject(List<Sale> Sales, string Category)
        {
            foreach (Sale sale in Sales)
            {
                if (sale.Category.Equals(Category))
                {
                    return sale;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public class CatalogViewModel
    {
        protected CatalogRepository catalogRepository = new CatalogRepository();
        protected ICatalogView view;
        private List<Category> categories;
        private List<Sale> sales;
        private List<Product> products;

        public CatalogViewModel(ICatalogView view)
        {
            this.view = view;
        }

        public async void GetCategories()
        {

            var getCategories = catalogRepository.GetCategoriesAsync().ContinueWith(categories =>
            {
                this.categories = categories.Result;
            });

            var getSales = catalogRepository.GetSalesAsync().ContinueWith(sales =>
            {
                this.sales = sales.Result;
            });

            var getProducts = catalogRepository.GetProductsAsync().ContinueWith(products =>
            {
                this.products = products.Result;
            });

            await Task.WhenAll(getCategories, getSales, getProducts).ContinueWith(result =>
            {

                if (result.IsCompleted && result.Status == TaskStatus.RanToCompletion)
                {
                    List<Object> preparedList = GetPreparedList(products, sales);
                    this.view.LoadData(categories, preparedList);
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

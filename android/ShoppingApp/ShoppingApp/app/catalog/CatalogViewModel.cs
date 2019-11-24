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
        private List<Categorie> categories;
        private List<Sale> sales;
        private List<Product> products;

        public CatalogViewModel(ICatalogView view)
        {
            this.view = view;
        }

        public async void GetCategories()
        {

            var getCategories = catalogRepository.GetCategoriesAsync().ContinueWith(categories => {
                this.categories = categories.Result;
            });

            var getSales = catalogRepository.GetSalesAsync().ContinueWith(sales => {
                this.sales = sales.Result;
            });

            var getProducts = catalogRepository.GetProductsAsync().ContinueWith(products => {
                this.products = products.Result;
            });

            await Task.WhenAll(getCategories, getSales, getProducts).ContinueWith( result => {

                if (result.IsCompleted && result.Status == TaskStatus.RanToCompletion)
                {
                    this.view.LoadData(categories, sales, products);                    
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
    }
}

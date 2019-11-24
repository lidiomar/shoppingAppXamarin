using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingApp.app.model
{
    public class CatalogRepository
    {
        private ICatalogDataSource catalogRemoteDataSource = new CatalogRemoteDataSource();
        private ICatalogDataSource catalogLocalDataSource = new CatalogLocalDataSource();

        public List<Category> categories;
        public List<Sale> sales;
        public List<Product> products;

        public Task GetCategoriesAsync()
        {
            Task task;

            if (App.DataBaseCreated())
            {
                task = catalogLocalDataSource.GetCategoriesAsync().ContinueWith(categoriesRequest =>
                {
                    categories = categoriesRequest.Result;
                });
            }
            else
            {
                task = catalogRemoteDataSource.GetCategoriesAsync().ContinueWith(async categoriesRequest =>
                {
                    categories = categoriesRequest.Result;
                    foreach (Category category in categories)
                    {
                        await App.Database.SaveCategoryAsync(category).ContinueWith(saveCategoriesRequest =>
                        {
                            //TODO 
                        });
                    }

                });
            }

            
            return task;

        }

        public Task GetSalesAsync()
        {
            return catalogRemoteDataSource.GetSalesAsync().ContinueWith(request =>
            {
                sales = request.Result;

            });

        }

        public Task GetProductsAsync()
        {
            Task task;

            if (App.DataBaseCreated())
            {
                task = catalogLocalDataSource.GetProductsAsync().ContinueWith(i =>
                {
                    products = i.Result;
                });
            }
            else
            {
                task = catalogRemoteDataSource.GetProductsAsync().ContinueWith(async i =>
                {
                    products = i.Result;
                    foreach (Product product in products)
                    {
                        await App.Database.SaveProductAsync(product).ContinueWith(saveCategoriesRequest =>
                        {
                            //TODO
                        });
                    }

                });
            }


            return task;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Droid.app;

namespace ShoppingApp.app.model.catalog
{
    public class CatalogRepository
    {
        private ICatalogDataSource catalogRemoteDataSource = new CatalogRemoteDataSource();
        private ICatalogDataSource catalogLocalDataSource = new CatalogLocalDataSource();
               
        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> local = await catalogLocalDataSource.GetCategoriesAsync();
            if(local.Count > 0)
            {
                //Log.Info("cacheControl", "categories loaded from LOCAL data source");
                return local;
            }

            List<Category> categories = await catalogRemoteDataSource.GetCategoriesAsync();
            foreach (Category category in categories)
            {
                await App.Database.SaveCategoryAsync(category).ContinueWith(i => {
                    if (i.IsFaulted || i.IsCanceled)
                    {
                        //TODO
                    }
                });
            }
            //Log.Info("cacheControl", "categories loaded from REMOTE data source");
            return categories;
            
        }

        public async Task<List<Sale>> GetSalesAsync()
        {
            List<Sale> local = await catalogRemoteDataSource.GetSalesAsync();
            return local;

        }

        public async Task<List<Product>> GetProductsAsync()
        {
            List<Product> local = await catalogLocalDataSource.GetProductsAsync();
            if (local.Count > 0)
            {
                //Log.Info("cacheControl", "products loaded from LOCAL data source");
                return local;
            }
            
            
            List<Product> products = await catalogRemoteDataSource.GetProductsAsync();
            foreach(Product product in products)
            {
                await App.Database.SaveProductAsync(product).ContinueWith(i => {
                    if(i.IsFaulted || i.IsCanceled)
                    {
                        //TODO
                    }
                });
            }
            //Log.Info("cacheControl","products loaded from REMOTE data source");
            return products;
            
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            List<Product> local = await catalogLocalDataSource.GetProductsByCategoryAsync(category);
            //Log.Info("cacheControl", "products BY CATEGORY loaded from LOCAL data source");
            return local;
            
        }
    }
}

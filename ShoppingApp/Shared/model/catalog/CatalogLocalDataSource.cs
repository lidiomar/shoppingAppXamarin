using System.Collections.Generic;
using System.Threading.Tasks;
using Droid.app;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.model.catalog
{
    public class CatalogLocalDataSource : ICatalogDataSource
    {
        public Task<List<Category>> GetCategoriesAsync()
        {
            Task<List<Category>> task = App.Database.GetCategoriesAsync();
            return task;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            Task<List<Product>> task = App.Database.GetProductsAsync();
            return task;
        }

        public Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            Task<List<Product>> task = App.Database.GetProductsByCategoryAsync(category);
            return task;
        }

        public Task<List<Sale>> GetSalesAsync()
        {
            /*Task<List<Sale>> task = App.Database.GetSalesAsync();
            return task;*/
            return null;
        }
    }
}

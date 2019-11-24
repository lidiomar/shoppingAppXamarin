using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.app.model
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

        public Task<List<Sale>> GetSalesAsync()
        {
            return null;
        }
        
    }
}

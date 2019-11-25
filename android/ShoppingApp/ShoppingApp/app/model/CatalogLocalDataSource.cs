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
            /*Task<List<Sale>> task = App.Database.GetSalesAsync();
            return task;*/
            return null;
        }

        public Task<int> UpdateProductAsync(Product product)
        {
            Task<int> task = App.Database.UpdateProductAsync(product);
            return task;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.app.model
{
    public class CatalogRemoteDataSource : ICatalogDataSource
    {
        public Task<List<Category>> GetCategoriesAsync()
        {
            var apiService = NetworkService.GetApiService();
            Task<List<Category>> task = apiService.GetCategories();
            return task;
     
        }

        public Task<List<Sale>> GetSalesAsync()
        {
            var apiService = NetworkService.GetApiService();
            Task<List<Sale>> task = apiService.GetSales();
            return task;

        }

        public Task<List<Product>> GetProductsAsync()
        {
            var apiService = NetworkService.GetApiService();
            Task<List<Product>> task = apiService.GetProducts();
            return task;

        }

        public Task<int> UpdateProductAsync(Product product)
        {
            return null;
        }
    }
}

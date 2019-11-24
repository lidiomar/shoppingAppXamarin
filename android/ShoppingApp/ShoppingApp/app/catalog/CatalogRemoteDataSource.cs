using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public class CatalogRemoteDataSource 
    {
        public CatalogRemoteDataSource()
        {
           
        }

        public Task<List<Categorie>> GetCategoriesAsync()
        {
            var apiService = NetworkService.GetApiService();
            Task<List<Categorie>> task = apiService.GetCategories();
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
    }
}

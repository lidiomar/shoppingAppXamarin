using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public class CatalogRepository
    {

        public Task<List<Category>> GetCategoriesAsync()
        {
            CatalogRemoteDataSource catalogRemoteDataSource = new CatalogRemoteDataSource();
            Task<List<Category>> task = catalogRemoteDataSource.GetCategoriesAsync();
            return task;
        }

        public Task<List<Sale>> GetSalesAsync()
        {
            CatalogRemoteDataSource catalogRemoteDataSource = new CatalogRemoteDataSource();
            Task<List<Sale>> task = catalogRemoteDataSource.GetSalesAsync();
            return task;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            CatalogRemoteDataSource catalogRemoteDataSource = new CatalogRemoteDataSource();
            Task<List<Product>> task = catalogRemoteDataSource.GetProductsAsync();
            return task;
        }
    }
}

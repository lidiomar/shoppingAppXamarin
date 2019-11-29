using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.model.catalog
{
    public interface ICatalogDataSource
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Sale>> GetSalesAsync();
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByCategoryAsync(string category);
    }
}

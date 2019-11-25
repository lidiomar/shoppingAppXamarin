using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.model.fragment
{
    public interface ICatalogDataSource
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Sale>> GetSalesAsync();
        Task<List<Product>> GetProductsAsync();
    }
}

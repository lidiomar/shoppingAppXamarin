using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.app.model
{
    public interface ICatalogDataSource
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Sale>> GetSalesAsync();
        Task<List<Product>> GetProductsAsync();
    }
}

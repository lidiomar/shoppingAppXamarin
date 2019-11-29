using System.Threading.Tasks;

namespace ShoppingApp.app.model.catalog
{
    public interface ICatalogAdapterDataSource
    {
        Task<int> UpdateProductAsync(Product product);
    }
}

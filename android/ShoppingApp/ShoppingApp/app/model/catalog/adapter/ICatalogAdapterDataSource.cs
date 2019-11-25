using System.Threading.Tasks;

namespace ShoppingApp.app.model.catalog.adapter
{
    public interface ICatalogAdapterDataSource
    {
        Task<int> UpdateProductAsync(Product product);
    }
}

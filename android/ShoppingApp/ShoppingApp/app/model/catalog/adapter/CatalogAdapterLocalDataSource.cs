using System.Threading.Tasks;

namespace ShoppingApp.app.model.catalog.adapter
{
    public class CatalogAdapterLocalDataSource : ICatalogAdapterDataSource
    {
        public Task<int> UpdateProductAsync(Product product)
        {
            Task<int> task = App.Database.UpdateProductAsync(product);
            return task;
        }
    }
}

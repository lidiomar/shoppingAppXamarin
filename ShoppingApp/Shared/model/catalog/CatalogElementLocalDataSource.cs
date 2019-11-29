using System.Threading.Tasks;
using Droid.app;

namespace ShoppingApp.app.model.catalog
{
    public class CatalogElementLocalDataSource : ICatalogAdapterDataSource
    {
        public Task<int> UpdateProductAsync(Product product)
        {
            Task<int> task = App.Database.UpdateProductAsync(product);
            return task;
        }
    }
}

using System.Threading.Tasks;

namespace ShoppingApp.app.model.catalog.adapter
{
    public class CatalogAdapterRepository
    {
        private ICatalogAdapterDataSource catalogAdapterLocalDataSource = new CatalogAdapterLocalDataSource();

        public CatalogAdapterRepository()
        {
        }

        public Task UpdateProductAsync(Product product)
        {
            return catalogAdapterLocalDataSource.UpdateProductAsync(product);
        }
    }
}

using System.Threading.Tasks;

namespace ShoppingApp.app.model.catalog
{
    public class CatalogElementRepository
    {
        private ICatalogAdapterDataSource catalogAdapterLocalDataSource = new CatalogElementLocalDataSource();

        public Task UpdateProductAsync(Product product)
        {
            return catalogAdapterLocalDataSource.UpdateProductAsync(product);
        }
    }
}

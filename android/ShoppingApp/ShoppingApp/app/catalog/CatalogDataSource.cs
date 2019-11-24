using System.Threading.Tasks;

namespace ShoppingApp.app.catalog
{
    public interface CatalogDataSource
    {
        Task GetCategoriesAsync();
    }
}

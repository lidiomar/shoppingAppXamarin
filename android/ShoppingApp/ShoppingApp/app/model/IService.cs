using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.model
{
    public interface IService
    {
        [Get("/raw/YNR2rsWe")]
        Task<List<Category>> GetCategories();

        [Get("/raw/R9cJFBtG")]
        Task<List<Sale>> GetSales();

        [Get("/raw/eVqp7pfX")]
        Task<List<Product>> GetProducts();
    }
}

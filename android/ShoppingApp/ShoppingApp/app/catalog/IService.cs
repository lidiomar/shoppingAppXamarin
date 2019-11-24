using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public interface IService
    {
        [Get("/raw/YNR2rsWe")]
        Task<List<Categorie>> GetCategories();

        [Get("/raw/R9cJFBtG")]
        Task<List<Sale>> GetSales();

        [Get("/raw/eVqp7pfX")]
        Task<List<Product>> GetProducts();
    }
}

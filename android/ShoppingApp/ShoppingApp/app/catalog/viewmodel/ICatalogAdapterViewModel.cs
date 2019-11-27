using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.catalog.viewmodel
{
    public interface ICatalogAdapterViewModel
    {
        Task UpdateProductAsync(Product product);

        List<Product> GetProductsToCart();

        float GetDiscountValue(float sumPrice, float discount);


        int GetNumberOfProductsSelected(Product product);

        float GetPercentDiscount(List<Policie> policies, float numberOfProductsSelected);


        void AddProductToCart(Product product, float value);


        int GetQuantity();


        float GetTotalValue();
        
    }

}

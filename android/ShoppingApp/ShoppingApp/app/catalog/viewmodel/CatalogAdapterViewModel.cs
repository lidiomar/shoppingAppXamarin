using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.catalog.view;
using ShoppingApp.app.model.catalog;
using ShoppingApp.app.model.catalog.adapter;

namespace ShoppingApp.app.catalog.viewmodel
{
    public class CatalogAdapterViewModel
    {
        private ICatalogAdapterView view;
        protected CatalogAdapterRepository catalogAdapterRepository = new CatalogAdapterRepository();

        public CatalogAdapterViewModel(ICatalogAdapterView view)
        {
            this.view = view;
        }

        public async Task UpdateProductAsync(Product product)
        {
            await catalogAdapterRepository.UpdateProductAsync(product).ContinueWith(result => {
                if (result.IsFaulted || result.IsCanceled)
                {
                    //TODO
                }
            });

        }

        public float GetDiscountValue(float sumPrice, float discount)
        {
            return sumPrice * discount / 100;
        }

        public int GetNumberOfProductsSelected(Product product)
        {
            return (int)Math.Round(product.SumPrice / product.Price);
        }

        public float GetPercentDiscount(List<Policie> policies, float numberOfProductsSelected)
        {
            float discount = 0;
            foreach (Policie policie in policies)
            {
                if (numberOfProductsSelected >= policie.Min)
                {
                    discount = policie.Discount;
                }
            }
            return discount;
        }
    }
}

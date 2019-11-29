using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.catalog.viewmodel
{
    public class CatalogElementViewModel : ICatalogElementViewModel
    {
        private readonly Dictionary<int, float> productValuesDict;
        private readonly Dictionary<int, Product> productsToCart;

        protected CatalogElementRepository catalogAdapterRepository = new CatalogElementRepository();

        public CatalogElementViewModel()
        {
            productsToCart = new Dictionary<int, Product>();
            productValuesDict = new Dictionary<int, float>();
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

        public List<Product> GetProductsToCart()
        {
            List<Product> products = new List<Product>();
            foreach (var item in productsToCart)
            {
                products.Add(item.Value);
            }
            return products;
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

        public void AddProductToCart(Product product, float value)
        {
            productValuesDict[product.Id] = value;

            if(value <= 0 && productsToCart.ContainsKey(product.Id))
            {
                productsToCart.Remove(product.Id);
            }else
            {
                productsToCart[product.Id] = product;
            }
        }

        public int GetQuantity()
        {
            int quantitty = 0;

            foreach (var item in productsToCart)
            {
                quantitty += item.Value.Quantity;
            }

            return quantitty;
        }

        public float GetTotalValue()
        {
            float totalValue = 0;

            foreach (var item in productValuesDict)
            {
                totalValue += item.Value;
            }

            return totalValue;
        }
    }
}

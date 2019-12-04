using System.Collections.Generic;
using NUnit.Framework;
using Shared;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model.catalog;

namespace ShoppingAppTest
{
    [TestFixture()]
    public class CatalogElementViewModelTest
    {

        [Test()]
        public void QuantityTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            Product product = GetProductInstance(1);

            product.SumPrice += product.Price;
            product.SumPrice += product.Price;

            product.Quantity = catalogElementViewModel.GetNumberOfProductsSelected(product);
            Assert.AreEqual(product.Quantity, 2);
        }

        [Test()]
        public void NoPercentDiscountTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            List<Policie> policies = GetPoliciesInstance();

            float percent = catalogElementViewModel.GetPercentDiscount(policies, 1f);
            Assert.AreEqual(percent, 0f);
        }

        [Test()]
        public void PercentDiscountTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            List<Policie> policies = GetPoliciesInstance();

            float percent = catalogElementViewModel.GetPercentDiscount(policies, 2f);
            Assert.AreEqual(percent, 20f);

            percent = catalogElementViewModel.GetPercentDiscount(policies, 3f);
            Assert.AreEqual(percent, 30f);

            percent = catalogElementViewModel.GetPercentDiscount(policies, 5f);
            Assert.AreEqual(percent, 30f);
        }

        [Test()]
        public void DiscountValueTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            float discountValue = catalogElementViewModel.GetDiscountValue(100f, 10f);
            Assert.AreEqual(discountValue, 10f);
        }

        [Test()]
        public void TotalValueTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            Product product1 = GetProductInstance(1);
            catalogElementViewModel.AddProductToCart(product1, 1);
            catalogElementViewModel.AddProductToCart(product1, 2);
            catalogElementViewModel.AddProductToCart(product1, 5);
            catalogElementViewModel.AddProductToCart(product1, 7);
            catalogElementViewModel.AddProductToCart(product1, 0);

            float totalValue = catalogElementViewModel.GetTotalValue();
            Assert.AreEqual(totalValue, 0f);
        }

        [Test()]
        public void MultipleProductsTotalValueTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            Product product1 = GetProductInstance(1);
            Product product2 = GetProductInstance(2);

            catalogElementViewModel.AddProductToCart(product1, 1);
            catalogElementViewModel.AddProductToCart(product2, 1);

            float totalValue = catalogElementViewModel.GetTotalValue();
            Assert.AreEqual(totalValue, 2f);

            catalogElementViewModel.AddProductToCart(product2, 0);
            totalValue = catalogElementViewModel.GetTotalValue();
            Assert.AreEqual(totalValue, 1f);
        }

        [Test()]
        public void GetProductsToCartTest()
        {
            CatalogElementViewModel catalogElementViewModel = new CatalogElementViewModel();
            Product product1 = GetProductInstance(1);
            Product product2 = GetProductInstance(2);
            Product product3 = GetProductInstance(3);
            Product product4 = GetProductInstance(4);

            catalogElementViewModel.AddProductToCart(product1, 1);
            catalogElementViewModel.AddProductToCart(product2, 1);
            catalogElementViewModel.AddProductToCart(product3, 1);
            catalogElementViewModel.AddProductToCart(product4, 1);

            List<Product> products = catalogElementViewModel.GetProductsToCart();
            Assert.AreEqual(products.Count, 4);
        }

        private Product GetProductInstance(int id)
        {
            Product product = new Product();
            product.Id = id;
            product.Name = "Product" + id.ToString();
            product.Description = "Product " + id.ToString() +" Description";
            product.Photo = "";
            product.Price = 10f;
            product.SumPrice = 0f;
            product.Quantity = 0;
            product.DiscountValue = 0;
            product.DiscountPercent = 0;
            product.Category = "1";
            product.Favorite = false;

            return product;
        }
        
        private List<Policie> GetPoliciesInstance()
        {
            List<Policie> policies = new List<Policie>();

            Policie policie20 = new Policie();
            policie20.Discount = 20f;
            policie20.Min = 2;
            policies.Add(policie20);

            Policie policie30 = new Policie();
            policie30.Discount = 30f;
            policie30.Min = 3;
            policies.Add(policie30);

            return policies;
        }
    }
}

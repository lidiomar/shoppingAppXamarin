using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingApp.app.catalog.view;
using ShoppingApp.app.model;
using ShoppingApp.app.model.catalog;
using ShoppingApp.app.model.fragment;

namespace ShoppingApp.app.catalog.viewmodel
{
    public class CatalogViewModel
    {
        protected CatalogRepository catalogRepository = new CatalogRepository();
        protected ICatalogView view;
        private List<Category> categories;
        private List<Sale> sales;
        private List<Product> products;
        public CatalogViewModel(ICatalogView view)
        {
            this.view = view;
        }

        public async Task GetData()
        {
            var getCategories = catalogRepository.GetCategoriesAsync().ContinueWith(i=> {
                categories = i.Result;
            });

            var getProducts = catalogRepository.GetProductsAsync().ContinueWith(i => {
                products = i.Result;
            });

            var getSales = catalogRepository.GetSalesAsync().ContinueWith(i => {
                sales = i.Result;
            });

            await Task.WhenAll(getCategories, getProducts, getSales).ContinueWith(result =>
            {

                if (result.IsCompleted && result.Status == TaskStatus.RanToCompletion)
                {
                    List<Object> preparedList = GetPreparedList(products, sales);
                    Dictionary<string, Sale> salesDict = GetSaleDictionary(sales);

                    this.view.LoadData(categories, preparedList, salesDict);
                }
                else if (result.IsFaulted)
                {
                    //TODO
                }
                else if (result.IsCanceled)
                {
                    //TODO
                }
            }, TaskScheduler.FromCurrentSynchronizationContext()).ConfigureAwait(false);
        }

        private List<Object> GetPreparedList(List<Product> Products, List<Sale> Sales)
        {
            List<Object> preparedList = new List<Object>();
            string currentCategory = "";
            foreach (Product product in Products)
            {
                if (currentCategory != product.Category)
                {
                    currentCategory = product.Category;
                    Sale sale = GetSaleObject(Sales, currentCategory);
                    preparedList.Add(sale);
                }
                preparedList.Add(product);
            }
            return preparedList;
        }

        private Sale GetSaleObject(List<Sale> Sales, string Category)
        {
            foreach (Sale sale in Sales)
            {
                if (sale.Category.Equals(Category))
                {
                    return sale;
                }
            }
            return null;
        }

        private Dictionary<string, Sale> GetSaleDictionary(List<Sale> Sales)
        {
            Dictionary<string, Sale> saleDict = new Dictionary<string, Sale>();

            foreach (Sale sale in Sales)
            {
                saleDict[sale.Category] = sale;
            }

            return saleDict;
        }
    }
}

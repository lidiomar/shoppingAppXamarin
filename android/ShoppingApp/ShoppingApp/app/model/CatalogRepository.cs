using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.app.model
{
    public class CatalogRepository
    {
        private ICatalogDataSource catalogRemoteDataSource = new CatalogRemoteDataSource();
        private ICatalogDataSource catalogLocalDataSource = new CatalogLocalDataSource();

        public List<Category> categories;
        public List<Sale> sales;
        public List<Product> products;

        public Task GetCategoriesAsync()
        {
            Task task;

            if (App.DataBaseCreated())
            {
                task = catalogLocalDataSource.GetCategoriesAsync().ContinueWith(categoriesRequest =>
                {
                    if (categoriesRequest.IsCanceled || categoriesRequest.IsFaulted)
                    {
                        //TODO
                    }
                    else
                    {
                        categories = categoriesRequest.Result;
                    }

                });
            }
            else
            {
                task = catalogRemoteDataSource.GetCategoriesAsync().ContinueWith(async categoriesRequest =>
                {
                    categories = categoriesRequest.Result;
                    foreach (Category category in categories)
                    {
                        await App.Database.SaveCategoryAsync(category).ContinueWith(saveCategoriesRequest =>
                        {
                            if (saveCategoriesRequest.IsCanceled || saveCategoriesRequest.IsFaulted)
                            {
                                //TODO
                            }
                            else
                            {
                                //TODO
                            }
                        });
                    }

                });
            }

            return task;
        }

        public Task GetSalesAsync()
        {
            return catalogRemoteDataSource.GetSalesAsync().ContinueWith(salesRequest =>
            {
                if (salesRequest.IsCanceled || salesRequest.IsFaulted)
                {
                    //TODO
                }
                else
                {
                    sales = salesRequest.Result;
                }
            });
        }

        public Task GetProductsAsync()
        {
            Task task;

            if (App.DataBaseCreated())
            {
                task = catalogLocalDataSource.GetProductsAsync().ContinueWith(productsRequest =>
                {
                    if (productsRequest.IsCanceled || productsRequest.IsFaulted)
                    {
                        //TODO
                    }
                    else
                    {
                        products = productsRequest.Result;
                    }
                });
            }
            else
            {
                task = catalogRemoteDataSource.GetProductsAsync().ContinueWith(async productsRequest =>
                {
                    products = productsRequest.Result;
                    foreach (Product product in products)
                    {
                        await App.Database.SaveProductAsync(product).ContinueWith(saveProductsRequest =>
                        {
                            if(saveProductsRequest.IsCanceled || saveProductsRequest.IsFaulted)
                            {
                                //TODO
                            }
                            else
                            {
                                //TODO
                            }

                        });
                    }

                });
            }
            return task;
        }

        public Task UpdateProductAsync(Product product)
        {
            return catalogLocalDataSource.UpdateProductAsync(product);
        }
    }
}

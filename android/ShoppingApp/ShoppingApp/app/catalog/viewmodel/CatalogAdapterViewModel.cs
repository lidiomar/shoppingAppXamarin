using System;
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
    }
}

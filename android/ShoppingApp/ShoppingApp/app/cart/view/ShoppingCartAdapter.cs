using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.cart.view
{
    public class ShoppingCartAdapter : RecyclerView.Adapter
    {
        private readonly List<Product> products;

        public ShoppingCartAdapter(List<Product> products)
        {
            this.products = products;
        }

        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((ShoppingCartViewHolder)holder).Bind((Product)products[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View catalogAdapterView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_shopping_cart, parent, false);
            return new ShoppingCartViewHolder(catalogAdapterView, parent.Context);
        }
    }
}

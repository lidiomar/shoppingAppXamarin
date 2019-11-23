using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace ShoppingApp.app.cart
{
    public class ShoppingCartAdapter : RecyclerView.Adapter
    {
        public ShoppingCartAdapter()
        {
        }

        public override int ItemCount => 20;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_shopping_cart,parent,false);
            return new ShoppingCartViewHolder(view);
        }
    }
}

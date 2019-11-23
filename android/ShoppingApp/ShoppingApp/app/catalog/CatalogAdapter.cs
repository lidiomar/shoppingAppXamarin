using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace ShoppingApp.app.catalog
{
    public class CatalogAdapter : RecyclerView.Adapter
    {
        public CatalogAdapter()
        {
        }

        public override int ItemCount => 20;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_catalog,parent,false);
            return new CatalogViewHolder(view);
        }
    }
}

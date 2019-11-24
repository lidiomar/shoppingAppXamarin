using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public class CatalogAdapter : RecyclerView.Adapter
    {
        private List<Object> products;

        private readonly int productView = 1;
        private readonly int saleView = 2;

        public CatalogAdapter(List<Object> products)
        {
            this.products = products;
        }

        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if(holder is CatalogViewHolder)
            {
                ((CatalogViewHolder)holder).Bind((Product)products[position]);
            } else if(holder is CatalogSectionViewHolder)
            {
                ((CatalogSectionViewHolder)holder).Bind((Sale)products[position]);
            }            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if(viewType == productView)
            {
                View catalogAdapterView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_catalog, parent, false);
                return new CatalogViewHolder(catalogAdapterView);
            }

            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.catalog_section, parent, false);
            return new CatalogSectionViewHolder(view);
            
        }

        public override int GetItemViewType(int position)
        {
            Object element = products[position];

            if(element is Product)
            {
                return productView;

            } else if(element == null || element is Sale)
            {
                return saleView;
            }

            return base.GetItemViewType(position);
        }
    }
}

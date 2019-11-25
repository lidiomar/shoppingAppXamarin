using System;
using System.Collections.Generic;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogAdapter : RecyclerView.Adapter
    {
        private List<Object> products;

        private readonly int productView = 1;
        private readonly int saleView = 2;
        private CatalogViewModel catalogViewModel;
        private Activity activity;

        public CatalogAdapter(List<Object> products, CatalogViewModel catalogViewModel, Activity activity )
        {
            this.products = products;
            this.catalogViewModel = catalogViewModel;
            this.activity = activity;
        }

        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if(holder is CatalogViewHolder)
            {
                ((CatalogViewHolder)holder).Bind((Product)products[position]);
                Button buttonFavorite = ((CatalogViewHolder)holder).buttonFavorite;

                if (((Product)products[position]).Favorite)
                {
                    ((CatalogViewHolder)holder).buttonFavorite.SetBackgroundResource(Resource.Drawable.ic_star_selected);
                }
                else
                {
                    ((CatalogViewHolder)holder).buttonFavorite.SetBackgroundResource(Resource.Drawable.ic_star);
                }
                ((CatalogViewHolder)holder).buttonFavorite.SetTag(Resource.Id.button_favorite, position);
                ((CatalogViewHolder)holder).buttonFavorite.Click -= ButtonFavorite_Click;
                ((CatalogViewHolder)holder).buttonFavorite.Click += ButtonFavorite_Click;


            } else if(holder is CatalogSectionViewHolder)
            {
                ((CatalogSectionViewHolder)holder).Bind((Sale)products[position]);
            }            
        }

        private void ButtonFavorite_Click(object sender, EventArgs eventArgs)
        {
            int position = (int)((Button)sender).GetTag(Resource.Id.button_favorite);

            if (((Product)products[position]).Favorite)
            {
                (sender as Button).SetBackgroundResource(Resource.Drawable.ic_star);
                ((Product)products[position]).Favorite = false;
            }
            else
            {
                (sender as Button).SetBackgroundResource(Resource.Drawable.ic_star_selected);
                ((Product)products[position]).Favorite = true;
            }

            catalogViewModel.UpdateProductAsync((Product)products[position]).ContinueWith(i => {
                if (i.IsFaulted || i.IsCanceled)
                {
                    string markAsfavoriteError = activity.GetString(Resource.String.favorite_error);
                    string markAsfavoriteErrorFormated = String.Format(markAsfavoriteError, ((Product)products[position])?.Name);
                    Toast.MakeText(activity, markAsfavoriteErrorFormated, ToastLength.Short).Show();
                }
            });
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if(viewType == productView)
            {
                View catalogAdapterView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_catalog, parent, false);
                return new CatalogViewHolder(catalogAdapterView, parent.Context);
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

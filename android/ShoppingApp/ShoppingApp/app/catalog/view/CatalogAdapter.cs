using System;
using System.Collections.Generic;
using Android.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogAdapter : RecyclerView.Adapter, ICatalogAdapterView
    {
        private List<Object> products;
        private readonly int plus = 0;
        private readonly int less = 1;

        private readonly int productView = 2;
        private readonly int saleView = 3;
        private CatalogAdapterViewModel catalogAdapterViewModel;
        private Activity activity;
        private Dictionary<string, Sale> salesDict;

        public CatalogAdapter(List<Object> products, Activity activity, Dictionary<string, Sale> salesDict)
        {
            this.products = products;
            this.catalogAdapterViewModel = new CatalogAdapterViewModel(this);
            this.activity = activity;
            this.salesDict = salesDict;
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

                ((CatalogViewHolder)holder).buttonFavorite.SetTag(Resource.Id.position, position);
                ((CatalogViewHolder)holder).buttonFavorite.Click -= ButtonFavorite_Click;
                ((CatalogViewHolder)holder).buttonFavorite.Click += ButtonFavorite_Click;

                ((CatalogViewHolder)holder).buttonPlus.SetTag(Resource.Id.position, position);
                ((CatalogViewHolder)holder).buttonPlus.SetTag(Resource.Id.button_quantity_action, plus);
                ((CatalogViewHolder)holder).buttonPlus.Click -= ButtonQuantity_Click;
                ((CatalogViewHolder)holder).buttonPlus.Click += ButtonQuantity_Click;

                ((CatalogViewHolder)holder).buttonLess.SetTag(Resource.Id.position, position);
                ((CatalogViewHolder)holder).buttonLess.SetTag(Resource.Id.button_quantity_action, less);
                ((CatalogViewHolder)holder).buttonLess.Click -= ButtonQuantity_Click;
                ((CatalogViewHolder)holder).buttonLess.Click += ButtonQuantity_Click;


            } else if(holder is CatalogSectionViewHolder)
            {
                ((CatalogSectionViewHolder)holder).Bind((Sale)products[position]);
            }            
        }
         
        private void ButtonQuantity_Click(object sender, EventArgs eventArgs)
        {
            int position = (int)((ImageButton)sender).GetTag(Resource.Id.position);
            int action = (int)((ImageButton)sender).GetTag(Resource.Id.button_quantity_action);
            Product product = (Product)products[position];

            if (action == plus)
            {
                ((Product)products[position]).SumPrice += product.Price;
            }else
            {
                ((Product)products[position]).SumPrice -= product.Price;
            }
            

            ((Product)products[position]).Quantity = GetNumberOfProductsSelected(product);
            float discount = 0;

            if (salesDict.ContainsKey(product.Category))
            {
                Sale sale = salesDict[product.Category];
                List<Policie> policies = sale.Policies;
                discount = GetPercentDiscount(policies, ((Product)products[position]).Quantity);
            }

            float discountValue = GetDiscountValue(((Product)products[position]).SumPrice, discount);
            float displayValue = ((Product)products[position]).SumPrice - discountValue;
            
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

        private void ButtonFavorite_Click(object sender, EventArgs eventArgs)
        {
            int position = (int)((Button)sender).GetTag(Resource.Id.position);

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

            catalogAdapterViewModel.UpdateProductAsync((Product)products[position]).ContinueWith(i => {
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

        public void ButtonClickResult()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogAdapter : RecyclerView.Adapter
    {
        public List<Object> products;
        private readonly int productView = 2;
        private readonly int saleView = 3;
        public ICatalogView catalogFragmentView;
        private Activity activity;
        public Dictionary<string, Sale> salesDict;

        public CatalogAdapter(List<Object> products, Activity activity, Dictionary<string, Sale> salesDict, ICatalogView view)
        {
            this.products = products;
            this.activity = activity;
            this.salesDict = salesDict;
            this.catalogFragmentView = view;
        }

        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is CatalogViewHolder)
            {
                ((CatalogViewHolder)holder).Bind((Product)products[position], false);

                if (((Product)products[position]).Favorite)
                {
                    ((CatalogViewHolder)holder).buttonFavorite.SetBackgroundResource(Resource.Drawable.ic_star_selected);
                }
                else
                {
                    ((CatalogViewHolder)holder).buttonFavorite.SetBackgroundResource(Resource.Drawable.ic_star);
                }

                ((CatalogViewHolder)holder).buttonFavorite.SetOnClickListener(null);
                ((CatalogViewHolder)holder).buttonFavorite.SetOnClickListener(new ClickFavorite((Product)products[position],activity));


                ((CatalogViewHolder)holder).buttonPlus.SetOnClickListener(null);
                ((CatalogViewHolder)holder).buttonPlus.SetOnClickListener(new ClickChangeItemCount(ClickChangeItemCount.plus, (CatalogViewHolder)holder, position, this));

                ((CatalogViewHolder)holder).buttonLess.SetOnClickListener(null);
                ((CatalogViewHolder)holder).buttonLess.SetOnClickListener(new ClickChangeItemCount(ClickChangeItemCount.less, (CatalogViewHolder)holder, position, this));

            }
            else if (holder is CatalogSectionViewHolder)
            {
                ((CatalogSectionViewHolder)holder).Bind((Sale)products[position]);
            }
        }

        

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == productView)
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

            if (element is Product)
            {
                return productView;
            }

            if (element == null || element is Sale)
            {
                return saleView;
            }

            return base.GetItemViewType(position);
        }
    }

    internal class ClickFavorite : Java.Lang.Object, View.IOnClickListener
    {
        public Product product;
        private readonly CatalogAdapterViewModel catalogAdapterViewModel;
        private readonly Context context;

        public ClickFavorite(Product product, Context context)
        {
            this.product = product;
            this.catalogAdapterViewModel = CatalogAdapterViewModel.GetInstance;
            this.context = context;
        }

        public void OnClick(View view)
        {
            if (product.Favorite)
            {
                (view as Button).SetBackgroundResource(Resource.Drawable.ic_star);
                product.Favorite = false;
            }
            else
            {
                (view as Button).SetBackgroundResource(Resource.Drawable.ic_star_selected);
                product.Favorite = true;
            }

            catalogAdapterViewModel.UpdateProductAsync(product).ContinueWith(i =>
            {
                if (i.IsFaulted || i.IsCanceled)
                {
                    string markAsfavoriteError = context.GetString(Resource.String.favorite_error);
                    string markAsfavoriteErrorFormated = String.Format(markAsfavoriteError, product?.Name);
                    Toast.MakeText(context, markAsfavoriteErrorFormated, ToastLength.Short).Show();
                }
            });
        }
    }

    internal class ClickChangeItemCount : Java.Lang.Object, View.IOnClickListener
    {
        private readonly int action;
        public static readonly int plus = 1;
        public static readonly int less = 2;
        private readonly Dictionary<string, Sale> salesDict;
        private readonly CatalogAdapterViewModel catalogAdapterViewModel;
        private readonly CatalogViewHolder viewHolder;
        private CatalogAdapter adapter;
        public Product product;

        public ClickChangeItemCount(int action, CatalogViewHolder viewHolder, int position, CatalogAdapter adapter)
        {
            this.action = action;
            salesDict = adapter.salesDict;
            this.catalogAdapterViewModel = CatalogAdapterViewModel.GetInstance;
            this.viewHolder = viewHolder;
            this.product = (Product)adapter.products[position];
            this.adapter = adapter;
        }

        public void OnClick(View v)
        {
            if (action == plus)
            {
                product.SumPrice += product.Price;
            }
            else
            {
                if(product.SumPrice <= 0)
                {
                    return;
                }
                product.SumPrice -= product.Price;
            }

            product.DiscountPercent = 0;
            product.Quantity = catalogAdapterViewModel.GetNumberOfProductsSelected(product);

            if(product.Quantity == 0)
            {
                product.SumPrice = 0;
            }

            if (product.Category != null && salesDict.ContainsKey(product.Category))
            {
                Sale sale = salesDict[product.Category];
                List<Policie> policies = sale.Policies;
                product.DiscountPercent = catalogAdapterViewModel.GetPercentDiscount(policies, product.Quantity);
            }
            
            product.DiscountValue = catalogAdapterViewModel.GetDiscountValue(product.SumPrice, product.DiscountPercent);

            viewHolder.Bind(product, true);

            catalogAdapterViewModel.IncrementTotalValue(product.Id, product.SumPrice - product.DiscountValue);
            float totalValue = catalogAdapterViewModel.GetTotalValue();
            adapter.catalogFragmentView.UpdateButtonBuyValue(totalValue);

        }
    }
}

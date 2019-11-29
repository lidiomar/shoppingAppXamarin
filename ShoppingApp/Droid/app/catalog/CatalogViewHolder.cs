using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp;
using ShoppingApp.app.model.catalog;
using Square.Picasso;

namespace Droid.app.catalog
{
    public class CatalogViewHolder : RecyclerView.ViewHolder
    {
        private TextView ProductName { get; set; }
        private TextView ProductDiscount { get; set; }
        private TextView ProductPrice { get; set; }
        private TextView NumberOfProducts { get; set; }
        public ImageButton ButtonLess { get; set; }
        public ImageButton ButtonPlus { get; set; }
        public Button ButtonFavorite { get; set; }
        private ImageView ProductImage { get; set; }

        private readonly Context context;
        private readonly Picasso picasso;

        public CatalogViewHolder(View view, Context context) : base(view)
        {
            this.ProductName = view.FindViewById<TextView>(Resource.Id.product_name);
            this.ProductDiscount = view.FindViewById<TextView>(Resource.Id.product_discount);
            this.ProductPrice = view.FindViewById<TextView>(Resource.Id.product_price);
            this.NumberOfProducts = view.FindViewById<TextView>(Resource.Id.number_of_products);
            this.ButtonLess = view.FindViewById<ImageButton>(Resource.Id.button_less);
            this.ButtonPlus = view.FindViewById<ImageButton>(Resource.Id.button_plus);
            this.ButtonFavorite = view.FindViewById<Button>(Resource.Id.button_favorite);
            this.ProductImage = view.FindViewById<ImageView>(Resource.Id.product_image);
            this.context = context;
            this.picasso = Picasso.With(context);

            /*
             * For development you can enable the display of a colored ribbon which indicates the image source
             *
             * https://square.github.io/picasso/
             *
             * Indicador Azul: Imagem carregada do disco
             * Indicador Vermelho: Rede
             * Indicador Verde: Memória
             */
            this.picasso.SetIndicatorsEnabled(false);
        }

        public void Bind(Product product, bool fromClick)
        {
            //Name
            ProductName.Text = product.Name;

            //Price
            if (product.SumPrice > 0)
            {
                float displayValue = product.SumPrice - product.DiscountValue;
                ProductPrice.Text = Utils.GetPrice(context, displayValue);
            }else
            {
                ProductPrice.Text = Utils.GetPrice(context, product.Price);
            }

            //Quantity
            if (product.Quantity > 0)
            {
                NumberOfProducts.Text = Utils.GetUN(context, product.Quantity.ToString());
                NumberOfProducts.Visibility = ViewStates.Visible;
            }
            else
            {
                NumberOfProducts.Visibility = ViewStates.Gone;
            }

            //Discount
            if (product.DiscountPercent > 0)
            {
                ProductDiscount.Text = Utils.GetDiscount(context, ((int)product.DiscountPercent).ToString());
                ProductDiscount.Visibility = ViewStates.Visible;
            }
            else
            {
                ProductDiscount.Visibility = ViewStates.Gone;
            }

            if (!fromClick)
            {
                string urlPhoto = product.Photo;
                this.picasso.Load(urlPhoto)
                    .Fit()
                    .CenterCrop()
                    .Placeholder(Resource.Drawable.ic_image_placeholder)
                    .Error(Resource.Drawable.ic_not_found)
                    .Into(ProductImage);
            }
            
        }
    }
}

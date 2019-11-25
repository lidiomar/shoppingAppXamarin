using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model;
using Square.Picasso;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogViewHolder : RecyclerView.ViewHolder
    {
        private TextView productName;
        private TextView productDiscount;
        private TextView productPrice;
        private TextView numberOfProducts;
        private ImageButton buttonLess;
        private ImageButton buttonPlus;
        public Button buttonFavorite { get; set; }
        private ImageView productImage;
        private Context context;
        private Picasso picasso;

        public CatalogViewHolder(View view, Context context) : base(view)
        {
            this.productName = view.FindViewById<TextView>(Resource.Id.product_name);
            this.productDiscount = view.FindViewById<TextView>(Resource.Id.product_discount);
            this.productPrice = view.FindViewById<TextView>(Resource.Id.product_price);
            this.numberOfProducts = view.FindViewById<TextView>(Resource.Id.number_of_products);
            this.buttonLess = view.FindViewById<ImageButton>(Resource.Id.button_less);
            this.buttonPlus = view.FindViewById<ImageButton>(Resource.Id.button_plus);
            this.buttonFavorite = view.FindViewById<Button>(Resource.Id.button_favorite);
            this.productImage = view.FindViewById<ImageView>(Resource.Id.product_image);
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
            this.picasso.SetIndicatorsEnabled(true);
        }

        public void Bind(Product product)
        {
            productDiscount.Visibility = ViewStates.Gone;
            numberOfProducts.Visibility = ViewStates.Gone;

            productName.Text = product.Name;
            string price = context.GetString(Resource.String.price);
            string priceFormated = String.Format(price, product?.Price.ToString("0.00"));

            productPrice.Text = priceFormated;

            string urlPhoto = product.Photo;

            this.picasso.Load(urlPhoto)
                .Fit()
                .CenterCrop()
                .Placeholder(Resource.Drawable.ic_image_placeholder)
                .Error(Resource.Drawable.ic_not_found)
                .Into(productImage);
        }
    }
}

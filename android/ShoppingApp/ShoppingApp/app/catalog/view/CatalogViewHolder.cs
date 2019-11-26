using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.model.catalog;
using Square.Picasso;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogViewHolder : RecyclerView.ViewHolder
    {
        private TextView productName { get; set; }
        private TextView productDiscount { get; set; }
        private TextView productPrice { get; set; }
        private TextView numberOfProducts { get; set; }
        public ImageButton buttonLess { get; set; }
        public ImageButton buttonPlus { get; set; }
        public Button buttonFavorite { get; set; }
        private ImageView productImage { get; set; }

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

        public void Bind(Product product, bool fromClick)
        {
            //Name
            productName.Text = product.Name;

            //Price
            if (product.SumPrice > 0)
            {
                float displayValue = product.SumPrice - product.DiscountValue;
                productPrice.Text = GetPrice(displayValue);
            }else
            {
                productPrice.Text = GetPrice(product.Price);
            }

            //Quantity
            if (product.Quantity > 0)
            {
                numberOfProducts.Text = GetUN(product.Quantity.ToString());
                numberOfProducts.Visibility = ViewStates.Visible;
            }
            else
            {
                numberOfProducts.Visibility = ViewStates.Gone;
            }

            //Discount
            if (product.DiscountPercent > 0)
            {
                productDiscount.Text = GetDiscount(((int)product.DiscountPercent).ToString());
                productDiscount.Visibility = ViewStates.Visible;
            }
            else
            {
                productDiscount.Visibility = ViewStates.Gone;
            }

            if (!fromClick)
            {
                string urlPhoto = product.Photo;
                this.picasso.Load(urlPhoto)
                    .Fit()
                    .CenterCrop()
                    .Placeholder(Resource.Drawable.ic_image_placeholder)
                    .Error(Resource.Drawable.ic_not_found)
                    .Into(productImage);
            }
            
        }

        private string GetPrice(float priceValue)
        {
            string price = context.GetString(Resource.String.price);
            string priceFormated = String.Format(price, priceValue.ToString("0.00"));
            return priceFormated;
        }

        private string GetUN(string quantity)
        {
            string un = context.GetString(Resource.String.un);
            string quantityFormated = String.Format(un, quantity);
            return quantityFormated;
        }

        private string GetDiscount(string discount)
        {
            string discountString = context.GetString(Resource.String.discount);
            string discountFormated = String.Format(discountString, discount);
            return discountFormated;
        }
    }
}

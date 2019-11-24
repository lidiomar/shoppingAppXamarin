using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog
{
    public class CatalogViewHolder : RecyclerView.ViewHolder
    {
        private TextView productName;
        private TextView productDiscount;
        private TextView productPrice;
        private TextView numberOfProducts;
        private ImageButton buttonLess;
        private ImageButton buttonPlus;
        private Button buttonFavorite;


        public CatalogViewHolder(View view) : base(view)
        {
            this.productName = view.FindViewById<TextView>(Resource.Id.product_name);
            this.productDiscount = view.FindViewById<TextView>(Resource.Id.product_discount);
            this.productPrice = view.FindViewById<TextView>(Resource.Id.product_price);
            this.numberOfProducts = view.FindViewById<TextView>(Resource.Id.number_of_products);
            this.buttonLess = view.FindViewById<ImageButton>(Resource.Id.button_less);
            this.buttonPlus = view.FindViewById<ImageButton>(Resource.Id.button_plus);
            this.buttonFavorite = view.FindViewById<Button>(Resource.Id.button_favorite);
            

        }

        public void Bind(Product product)
        {
            productDiscount.Visibility = ViewStates.Gone;
            numberOfProducts.Visibility = ViewStates.Gone;

            productName.Text = product.Name;
            productPrice.Text = product.Price.ToString();
        }
    }
}

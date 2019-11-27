using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.model.catalog;
using Square.Picasso;

namespace ShoppingApp.app.cart.view
{
    public class ShoppingCartViewHolder : RecyclerView.ViewHolder
    {
        private readonly Context context;
        private readonly Picasso picasso;
        private readonly ImageView ProductImage;
        private readonly TextView ProductName;
        private readonly TextView NumberOfProducts;
        private readonly TextView ProductDiscount;
        private readonly TextView ProductPrice;

        public ShoppingCartViewHolder(View view, Context context) : base(view)
        {
            ProductImage = view.FindViewById<ImageView>(Resource.Id.product_image);
            ProductName = view.FindViewById<TextView>(Resource.Id.product_name);
            NumberOfProducts = view.FindViewById<TextView>(Resource.Id.number_of_products);
            ProductDiscount = view.FindViewById<TextView>(Resource.Id.product_discount);
            ProductPrice = view.FindViewById<TextView>(Resource.Id.product_price);

            this.context = context;
            this.picasso = Picasso.With(context);
        }

        public void Bind(Product product)
        {
            //Name
            ProductName.Text = product.Name;

            //Price
            float displayValue = product.SumPrice - product.DiscountValue;
            ProductPrice.Text = Utils.GetPrice(context, displayValue);

            //Quantity
            NumberOfProducts.Text = Utils.GetUN(context, product.Quantity.ToString());

            //Discount
            if (product.DiscountPercent > 0)
            {
                ProductDiscount.Text = Utils.GetDiscount(context, ((int)product.DiscountPercent).ToString());
                ProductDiscount.Visibility = ViewStates.Visible;
            }
            else
            {
                ProductDiscount.Visibility = ViewStates.Invisible;
            }

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

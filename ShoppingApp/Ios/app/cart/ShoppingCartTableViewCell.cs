using System;

using Foundation;
using UIKit;
using SDWebImage;
using ShoppingApp.app.model.catalog;
using Shared;

namespace Ios.app.cart
{
    public partial class ShoppingCartTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ShoppingCartTableViewCell");
        public static readonly UINib Nib;
        public Product product;

        static ShoppingCartTableViewCell()
        {
            Nib = UINib.FromName("ShoppingCartTableViewCell", NSBundle.MainBundle);
        }

        public static ShoppingCartTableViewCell Create()
        {
            return (ShoppingCartTableViewCell)Nib.Instantiate(null, null)[0];
        }

        protected ShoppingCartTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            ProductImage.SetImage(new NSUrl(product.Photo));
            ProductName.Text = product.Name;

            float displayValue = product.SumPrice - product.DiscountValue;
            ProductPrice.Text = Utils.GetPrice(NSBundle.MainBundle.GetLocalizedString("price", " "), displayValue);

            ProductQuantity.Text = Utils.GetUN(NSBundle.MainBundle.GetLocalizedString("un", " "), product.Quantity.ToString());

            //Discount
            if (product.DiscountPercent > 0)
            {
                ProductDiscount.Text = Utils.GetDiscount(NSBundle.MainBundle.GetLocalizedString("discount", " "), ((int)product.DiscountPercent).ToString());
                ProductDiscount.Hidden = false;
            }
            else
            {
                ProductDiscount.Hidden = true;
            }
        }
    }
}

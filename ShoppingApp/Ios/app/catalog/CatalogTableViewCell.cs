using System;

using Foundation;
using UIKit;
using SDWebImage;
using ShoppingApp.app.model.catalog;

namespace Ios.app.catalog
{
    public partial class CatalogTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CatalogTableViewCell");
        public static readonly UINib Nib = UINib.FromName("CatalogTableViewCell", NSBundle.MainBundle);
        public Product product;

        static CatalogTableViewCell()
        {
            Nib = UINib.FromName("CatalogTableViewCell", NSBundle.MainBundle);
        }

        public static CatalogTableViewCell Create()
        {
            return (CatalogTableViewCell)Nib.Instantiate(null, null)[0];
        }

        protected CatalogTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            string photoUrl = product.Photo;
            ProductImage.SetImage(new NSUrl(photoUrl));
            ProductDescription.Text = product.Name;
           
            string price = NSBundle.MainBundle.GetLocalizedString("price", " ");
            string priceFormated = String.Format(price, product.Price.ToString("0.00"));
            ProductPrice.Text = priceFormated;

            ProductDiscount.Hidden |= product.DiscountPercent <= 0;

            ProductQuantity.Hidden |= product.Quantity <= 0;


            //ProductPrice.Text = product.Price;
        }

        
    }
}

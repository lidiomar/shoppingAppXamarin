using System;

using Foundation;
using UIKit;

namespace Ios.app.catalog
{
    public partial class SaleTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("SaleTableViewCell");
        public static readonly UINib Nib;
        public string saleDescriptionText;

        static SaleTableViewCell()
        {
            Nib = UINib.FromName("SaleTableViewCell", NSBundle.MainBundle);
        }

        public static SaleTableViewCell Create()
        {
            return (SaleTableViewCell)Nib.Instantiate(null, null)[0];
        }

        protected SaleTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            SaleDescription.Text = saleDescriptionText;
        }
    }
}

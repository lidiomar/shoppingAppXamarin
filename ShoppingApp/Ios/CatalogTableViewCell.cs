using System;

using Foundation;
using UIKit;

namespace Ios
{
    public partial class CatalogTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CatalogTableViewCell");
        public static readonly UINib Nib = UINib.FromName("CatalogTableViewCell", NSBundle.MainBundle);

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
    }
}

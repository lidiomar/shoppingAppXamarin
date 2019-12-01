using Foundation;
using System;
using UIKit;

namespace Ios
{
    public partial class ShoppingCartViewController : UIViewController
    {
        public ShoppingCartViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadTable();
        }

        protected void LoadTable()
        {
            tableViewShoppingCart.SeparatorColor = UIColor.FromRGB(127, 106, 0);
            tableViewShoppingCart.Source = new ShoppingCartTableSource(this);
        }
    }
}
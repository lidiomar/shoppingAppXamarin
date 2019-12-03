// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Ios.app.cart
{
    [Register ("ShoppingCartViewController")]
    partial class ShoppingCartViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Checkout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PriceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewShoppingCart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TotalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UnLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Checkout != null) {
                Checkout.Dispose ();
                Checkout = null;
            }

            if (PriceLabel != null) {
                PriceLabel.Dispose ();
                PriceLabel = null;
            }

            if (tableViewShoppingCart != null) {
                tableViewShoppingCart.Dispose ();
                tableViewShoppingCart = null;
            }

            if (TotalLabel != null) {
                TotalLabel.Dispose ();
                TotalLabel = null;
            }

            if (UnLabel != null) {
                UnLabel.Dispose ();
                UnLabel = null;
            }
        }
    }
}
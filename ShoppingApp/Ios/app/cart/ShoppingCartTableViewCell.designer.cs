// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Ios.app.cart
{
    [Register ("ShppingCartTableViewCell")]
    partial class ShoppingCartTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductDiscount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProductImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductPrice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductQuantity { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProductDiscount != null) {
                ProductDiscount.Dispose ();
                ProductDiscount = null;
            }

            if (ProductImage != null) {
                ProductImage.Dispose ();
                ProductImage = null;
            }

            if (ProductName != null) {
                ProductName.Dispose ();
                ProductName = null;
            }

            if (ProductPrice != null) {
                ProductPrice.Dispose ();
                ProductPrice = null;
            }

            if (ProductQuantity != null) {
                ProductQuantity.Dispose ();
                ProductQuantity = null;
            }
        }
    }
}
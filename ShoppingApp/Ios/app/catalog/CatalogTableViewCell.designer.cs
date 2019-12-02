// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Ios.app.catalog
{
    [Register ("CatalogTableViewCell")]
    partial class CatalogTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonFavorite { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonLess { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonPlus { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductDiscount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProductImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductPrice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductQuantity { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonFavorite != null) {
                ButtonFavorite.Dispose ();
                ButtonFavorite = null;
            }

            if (ButtonLess != null) {
                ButtonLess.Dispose ();
                ButtonLess = null;
            }

            if (ButtonPlus != null) {
                ButtonPlus.Dispose ();
                ButtonPlus = null;
            }

            if (ProductDescription != null) {
                ProductDescription.Dispose ();
                ProductDescription = null;
            }

            if (ProductDiscount != null) {
                ProductDiscount.Dispose ();
                ProductDiscount = null;
            }

            if (ProductImage != null) {
                ProductImage.Dispose ();
                ProductImage = null;
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
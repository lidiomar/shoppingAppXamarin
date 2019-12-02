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
        UIKit.UIImageView ProductImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonFavorite != null) {
                ButtonFavorite.Dispose ();
                ButtonFavorite = null;
            }

            if (ProductImage != null) {
                ProductImage.Dispose ();
                ProductImage = null;
            }
        }
    }
}
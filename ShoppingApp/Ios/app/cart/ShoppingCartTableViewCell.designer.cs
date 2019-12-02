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
        UIKit.UIImageView ProductImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProductImage != null) {
                ProductImage.Dispose ();
                ProductImage = null;
            }
        }
    }
}
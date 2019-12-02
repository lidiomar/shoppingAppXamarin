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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIView errorView { get; set; }


        [Outlet]
        UIKit.UIView loadingView { get; set; }


        [Outlet]
        UIKit.UIView mainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem FIlterBarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewCatalog { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FIlterBarButton != null) {
                FIlterBarButton.Dispose ();
                FIlterBarButton = null;
            }

            if (tableViewCatalog != null) {
                tableViewCatalog.Dispose ();
                tableViewCatalog = null;
            }
        }
    }
}
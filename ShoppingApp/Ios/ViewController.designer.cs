// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Ios
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewCatalog { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tableViewCatalog != null) {
                tableViewCatalog.Dispose ();
                tableViewCatalog = null;
            }
        }
    }
}
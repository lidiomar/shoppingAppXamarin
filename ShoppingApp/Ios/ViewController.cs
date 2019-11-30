using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Ios
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            CreateTableItems();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        protected void CreateTableItems()
        {
            tableViewCatalog.SeparatorColor = UIColor.FromRGB(127, 106, 0);

            List<TableItem> tableItems = new List<TableItem>
            {
                new TableItem("Vegetables") { SubHeading = "65 items", ImageName = "Vegetables.jpg" },
                new TableItem("Fruits") { SubHeading = "17 items", ImageName = "Fruits.jpg" },
                new TableItem("Flower Buds") { SubHeading = "5 items", ImageName = "Flower Buds.jpg" },
                new TableItem("Legumes") { SubHeading = "33 items", ImageName = "Legumes.jpg" },
                new TableItem("Bulbs") { SubHeading = "18 items", ImageName = "Bulbs.jpg" },
                new TableItem("Tubers") { SubHeading = "43 items", ImageName = "Tubers.jpg" }
            };
            tableViewCatalog.Source = new TableSource(tableItems, this);
        }
    }
}

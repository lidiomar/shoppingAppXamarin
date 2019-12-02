using System;
using Foundation;
using UIKit;

namespace Ios.app.cart
{
    public class ShoppingCartTableSource: UITableViewSource
    {
        private UIViewController owner;
        NSString cellIdentifier = new NSString("ShoppingCartTableCell");

        public ShoppingCartTableSource(UIViewController owner)
        {
            this.owner = owner;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            ShoppingCartTableViewCell cell = tableView.DequeueReusableCell(ShoppingCartTableViewCell.Key) as ShoppingCartTableViewCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = ShoppingCartTableViewCell.Create();

            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 20;
        }
    }
}

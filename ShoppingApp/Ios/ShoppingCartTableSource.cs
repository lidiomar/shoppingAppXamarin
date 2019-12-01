using System;
using Foundation;
using UIKit;

namespace Ios
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
            ShppingCartTableViewCell cell = tableView.DequeueReusableCell(ShppingCartTableViewCell.Key) as ShppingCartTableViewCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = ShppingCartTableViewCell.Create();

            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 20;
        }
    }
}

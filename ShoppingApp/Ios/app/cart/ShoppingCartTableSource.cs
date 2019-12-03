using System;
using System.Collections.Generic;
using Foundation;
using ShoppingApp.app.model.catalog;
using UIKit;

namespace Ios.app.cart
{
    public class ShoppingCartTableSource: UITableViewSource
    {
        private List<Product> products;
        NSString cellIdentifier = new NSString("ShoppingCartTableCell");

        public ShoppingCartTableSource(List<Product> products)
        {
            this.products = products;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            ShoppingCartTableViewCell cell = tableView.DequeueReusableCell(ShoppingCartTableViewCell.Key) as ShoppingCartTableViewCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = ShoppingCartTableViewCell.Create();
            }
            cell.product = this.products[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this.products.Count;
        }
    }
}

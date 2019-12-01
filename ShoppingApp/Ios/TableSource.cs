using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace Ios
{
    public class TableSource : UITableViewSource
    {
        List<TableItem> tableItems;
        private UIViewController owner;
        NSString cellIdentifier = new NSString("TableCell");

        public TableSource(UIViewController owner)
        {
            this.owner = owner;
        }
        
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 20;
        }
        
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            CatalogTableViewCell cell = tableView.DequeueReusableCell(CatalogTableViewCell.Key) as CatalogTableViewCell;

            if (cell == null)
            {
                cell = CatalogTableViewCell.Create();
                
            }

            return cell;
        }
    }
}
   
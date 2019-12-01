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
        private ViewController owner;
        NSString cellIdentifier = new NSString("TableCell");

        public TableSource(List<TableItem> items, ViewController owner)
        {
            tableItems = items;
            this.owner = owner;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        /// <summary>
        /// Called when a row is touched
        /// </summary>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIAlertController okAlertController = UIAlertController.Create("Row Selected", tableItems[indexPath.Row].Heading, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            owner.PresentViewController(okAlertController, true, null);

            tableView.DeselectRow(indexPath, true);
        }

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            CatalogTableViewCell cell = tableView.DequeueReusableCell(CatalogTableViewCell.Key) as CatalogTableViewCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = CatalogTableViewCell.Create();
                
            }

            return cell;
        }
    }
}
   
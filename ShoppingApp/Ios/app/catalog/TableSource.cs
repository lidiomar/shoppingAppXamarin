using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using ShoppingApp.app.model.catalog;
using UIKit;

namespace Ios.app.catalog
{
    public class TableSource : UITableViewSource
    {
        private UIViewController owner;
        NSString cellIdentifier = new NSString("TableCell");
        List<object> preparedList = new List<object>();
        Dictionary<string, Sale> salesDict = new Dictionary<string, Sale>();

        public TableSource(UIViewController owner, List<object> preparedList, Dictionary<string, Sale> salesDict)
        {
            this.owner = owner;
            this.preparedList = preparedList;
            this.salesDict = salesDict;
        }
        
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return preparedList.Count;
        }
        
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            object item = preparedList[indexPath.Row];
            UITableViewCell cell;

            if (item is Product)
            {
                cell = tableView.DequeueReusableCell(CatalogTableViewCell.Key) as CatalogTableViewCell;
                if (cell == null)
                {
                    cell = CatalogTableViewCell.Create();
                }
                ((CatalogTableViewCell)cell).product = (Product)item;
            }
            else
            {
                cell = tableView.DequeueReusableCell(SaleTableViewCell.Key) as SaleTableViewCell;
                if (cell == null)
                {
                    cell = SaleTableViewCell.Create();
                }
                
                Sale sale = (Sale)item;
                string description = "";
                if (sale != null)
                {
                    description = sale.Name;
                }

                ((SaleTableViewCell)cell).saleDescriptionText = description;

            }

            return cell;
        }
    }
}
   
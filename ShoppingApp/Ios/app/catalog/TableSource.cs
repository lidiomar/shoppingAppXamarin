using System;
using System.Collections.Generic;
using Foundation;
using Shared.view;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model.catalog;
using UIKit;

namespace Ios.app.catalog
{
    public class TableSource : UITableViewSource
    {
        NSString cellIdentifier = new NSString("TableCell");
        public List<object> preparedList = new List<object>();
        public Dictionary<string, Sale> salesDict = new Dictionary<string, Sale>();
        public CatalogElementViewModel catalogElementViewModel;
        public ICatalogView owner;

        public TableSource(ICatalogView owner, List<object> preparedList, Dictionary<string, Sale> salesDict)
        {
            this.preparedList = preparedList;
            this.salesDict = salesDict;
            this.owner = owner;
            catalogElementViewModel = new CatalogElementViewModel();
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
                ((CatalogTableViewCell)cell).tableSource = this;
                ((CatalogTableViewCell)cell).position = indexPath.Row;
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
   
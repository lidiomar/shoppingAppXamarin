using Foundation;
using Shared;
using ShoppingApp.app.model.catalog;
using System;
using System.Collections.Generic;
using UIKit;

namespace Ios.app.cart
{
    public partial class ShoppingCartViewController : UIViewController
    {
        public List<Product> products;
        public int quantity;
        public float totalValue;

        public ShoppingCartViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Checkout.SetTitle(NSBundle.MainBundle.GetLocalizedString("checkout", ""), UIControlState.Normal);
            UnLabel.Text = Utils.GetUN(NSBundle.MainBundle.GetLocalizedString("un", ""), quantity.ToString());
            TotalLabel.Text = NSBundle.MainBundle.GetLocalizedString("total", " ");
            PriceLabel.Text = Utils.GetPrice(NSBundle.MainBundle.GetLocalizedString("price", ""), totalValue);

            LoadTable();
        }

        protected void LoadTable()
        {
            tableViewShoppingCart.TableFooterView = new UIView();
            tableViewShoppingCart.SeparatorColor = UIColor.FromRGB(217, 217, 217);
            tableViewShoppingCart.Source = new ShoppingCartTableSource(products);
        }
    }
}
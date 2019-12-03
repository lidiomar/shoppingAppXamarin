using Foundation;
using Ios.app.cart;
using Shared.view;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model.catalog;
using System;
using System.Collections.Generic;
using UIKit;

namespace Ios.app.catalog
{
    public partial class ViewController : UIViewController, ICatalogView
    {
        protected CatalogViewModel catalogViewModel;
        private TableSource tableSource;
        private List<object> tableSourceList;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            tableSource = null;
            tableSourceList = null;
            catalogViewModel = null;
            catalogViewModel = new CatalogViewModel(this);

            tableViewCatalog.TableFooterView = new UIView();
            tableViewCatalog.SeparatorColor = UIColor.FromRGB(217, 217, 217);

            _ = catalogViewModel.GetData();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier.Equals("buttonBuySegue"))
            {
                ShoppingCartViewController shoppingCartViewController = (ShoppingCartViewController)segue.DestinationViewController;

                shoppingCartViewController.products = tableSource.catalogElementViewModel.GetProductsToCart();
                shoppingCartViewController.quantity = tableSource.catalogElementViewModel.GetQuantity();
                shoppingCartViewController.totalValue = tableSource.catalogElementViewModel.GetTotalValue();

            }
            base.PrepareForSegue(segue, sender);
        }

        private void SetupButtonFilter(List<Category> categories)
        {
            FilterBarButton.Clicked += (s, e) => {
                UIAlertController alertController = GetAlertController(categories);
                PresentViewController(alertController, true, null);
            };
        }

        private UIAlertController GetAlertController(List<Category> categories)
        {
            UIAlertController alertController = UIAlertController.Create(null, null, preferredStyle: UIAlertControllerStyle.ActionSheet);
            alertController.AddAction(UIAlertAction.Create(NSBundle.MainBundle.GetLocalizedString("all_categories", " "), UIAlertActionStyle.Default, (a) => {
                _ = catalogViewModel.GetData();
            }));

            foreach (Category category in categories)
            {
                alertController.AddAction(UIAlertAction.Create(category.Name, UIAlertActionStyle.Default, (a) => {
                    _ = catalogViewModel.GetProductsByCategory(category.Id.ToString());
                }));
            }

            alertController.AddAction(UIAlertAction.Create(NSBundle.MainBundle.GetLocalizedString("cancel", " "), UIAlertActionStyle.Cancel, (a) => { }));
            alertController.View.TintColor = UIColor.Black;
            return alertController;
        }

        public void LoadData(List<Category> categories, List<object> preparedList, Dictionary<string, Sale> salesDict)
        {
            ShowMain();

            if(tableSource == null)
            {
                tableSourceList = preparedList;
                tableSource = new TableSource(this, tableSourceList, salesDict);
                tableViewCatalog.Source = tableSource;
                tableViewCatalog.ReloadData();
                SetupButtonFilter(categories);
                UpdateButtonBuyValue(0);
            }
            else
            {
                LoadFiteredData(preparedList);
            }
        }

        public void LoadFiteredData(List<object> preparedList)
        {
            ShowMain();

            tableSourceList.Clear();
            foreach (object o in preparedList)
            {
                this.tableSourceList.Add(o);
            }

            UpdateButtonBuyValue(0);
            tableViewCatalog.ReloadData();
        }

        public void UpdateButtonBuyValue(float value)
        {
            string format = NSBundle.MainBundle.GetLocalizedString("buy_value", " ");
            string formatted = String.Format(format, value.ToString("0.00"));
            buttonBuy.SetTitle(formatted, UIControlState.Normal);

            if (value <= 0)
            {
                buttonBuy.Enabled = false;
                buttonBuy.Alpha = 0.5f;
            }
            else
            {
                buttonBuy.Enabled = true;
                buttonBuy.Alpha = 1.0f;
            }
        }

        public void IsLoading()
        {
            mainView.Hidden = true;
            errorView.Hidden = true;
            loadingView.Hidden = false;
        }

        public void ShowErrorMessage()
        {
            mainView.Hidden = true;
            errorView.Hidden = false;
            loadingView.Hidden = true;
        }

        public void ShowMain()
        {
            mainView.Hidden = false;
            errorView.Hidden = true;
            loadingView.Hidden = true;
        }
    }
}

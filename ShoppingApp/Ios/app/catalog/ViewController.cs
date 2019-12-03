using Foundation;
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
            catalogViewModel = new CatalogViewModel(this);
            _ = catalogViewModel.GetData();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void SetupButtonFilter(List<Category> categories)
        {
            FIlterBarButton.Clicked += (s, e) => {
                UIAlertController alertController = GetAlertController(categories);
                this.PresentViewController(alertController, true, null);
            };
        }

        private UIAlertController GetAlertController(List<Category> categories)
        {
            UIAlertController alertController = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);
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
            tableViewCatalog.SeparatorColor = UIColor.FromRGB(127, 106, 0);

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

            this.tableSourceList.Clear();
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
            }
            else
            {
                buttonBuy.Enabled = true;
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

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

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad();
            catalogViewModel = new CatalogViewModel(this);
            tableViewCatalog.SeparatorColor = UIColor.FromRGB(127, 106, 0);
            tableViewCatalog.Source = new TableSource(this);
            //_ = catalogViewModel.GetData();

            ButtonFilter();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        protected void ButtonFilter()
        {
            FIlterBarButton.Clicked += (s, e) => {
                UIAlertController okAlertController = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);

                okAlertController.AddAction(UIAlertAction.Create("Title1", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title2", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title3", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title4", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title5", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title6", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title7", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title8", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title9", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title10", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title11", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title12", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title13", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title14", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title15", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title16", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title17", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title18", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title19", UIAlertActionStyle.Default, (a) => { }));
                okAlertController.AddAction(UIAlertAction.Create("Title20", UIAlertActionStyle.Default, (a) => { }));

                okAlertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (a) => { }));

                okAlertController.View.TintColor = UIColor.Black;
                this.PresentViewController(okAlertController, true, null);
                okAlertController.View.TintColor = UIColor.Black;
            };
        }

        public void LoadData(List<Category> categories, List<object> preparedList, Dictionary<string, Sale> salesDict)
        {
        }

        public void LoadFiteredData(List<object> preparedList)
        {
            
        }

        public void UpdateButtonBuyValue(float value)
        {
            
        }

        public void IsLoading()
        {
            
        }

        public void ShowErrorMessage()
        {
            
        }
    }
}

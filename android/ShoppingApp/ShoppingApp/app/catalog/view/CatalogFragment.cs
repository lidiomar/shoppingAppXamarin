using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.cart.view;
using ShoppingApp.app.catalog.viewmodel;
using ShoppingApp.app.model.catalog;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogFragment : Fragment, ICatalogView  
    {

        protected CatalogViewModel catalogViewModel;
        private RecyclerView recyclerView;
        private Button buttonBuy;
        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            catalogViewModel = new CatalogViewModel(this);
            _ = catalogViewModel.GetData();

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.fragment_catalog, container, false);
            SetupRecyclerView(view);
            SetupButtonBuy(view);
            return view;
                     
        }

        private void SetupRecyclerView(View view)
        {
            this.recyclerView = view.FindViewById<RecyclerView>(Resource.Id.catalog_recyclerview);
        }

        private void SetupButtonBuy(View view)
        {
            buttonBuy = view.FindViewById<Button>(Resource.Id.button_buy);
            buttonBuy.Click += (sender, e) =>
            {
                Intent intent = new Intent(Activity, typeof(ShoppingCartActivity));
                Activity.StartActivity(intent);
            };

            UpdateButtonBuyValue(0);
        }

        public void UpdateButtonBuyValue(float value)
        {
            string format = Activity.GetString(Resource.String.buy_value);
            string formatted = String.Format(format, value.ToString("0.00"));
            buttonBuy.Text = formatted;

            if (value <= 0)
            {
                buttonBuy.Enabled = false;
            }else
            {
                buttonBuy.Enabled = true;
            }
        }

        public void LoadData(List<Category> categories, List<Object> preparedList, Dictionary<string, Sale> salesDict)
        {
            CatalogAdapter catalogAdapter = new CatalogAdapter(preparedList, Activity, salesDict, this);
            recyclerView.SetAdapter(catalogAdapter);
        }
    }
}

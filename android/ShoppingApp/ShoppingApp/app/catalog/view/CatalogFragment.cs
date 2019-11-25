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
using ShoppingApp.app.model;

namespace ShoppingApp.app.catalog.view
{
    public class CatalogFragment : Fragment, ICatalogView  
    {

        protected CatalogViewModel catalogViewModel;
        private RecyclerView recyclerView;

        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            catalogViewModel = new CatalogViewModel(this);
            _ = catalogViewModel.GetCategories();

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
            Button buttonBuy = view.FindViewById<Button>(Resource.Id.button_buy);
            buttonBuy.Click += (sender, e) =>
            {
                Intent intent = new Intent(Activity, typeof(ShoppingCartActivity));
                Activity.StartActivity(intent);
            };
        }

        public void LoadData(List<Category> categories, List<Object> preparedList)
        {
            CatalogAdapter catalogAdapter = new CatalogAdapter(preparedList, catalogViewModel, Activity);
            recyclerView.SetAdapter(catalogAdapter);
        }
    }
}

﻿using System;
using System.Collections.Generic;


using Android.Content;
using Android.OS;
using Android.Support.V4.App;
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
        private List<Category> categories;
        private CatalogAdapter catalogAdapter;
        private Android.Runtime.JavaList<Object> preparedList;
        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            catalogViewModel = new CatalogViewModel(this);
            _ = catalogViewModel.GetData();
            HasOptionsMenu = true;
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

        public void LoadData(List<Category> categories, Android.Runtime.JavaList<Object> preparedList, Dictionary<string, Sale> salesDict)
        {
            if(categories.Count > 0)
            {
                this.categories = categories;
                Activity.InvalidateOptionsMenu();
            }

            this.preparedList = preparedList;

            catalogAdapter = new CatalogAdapter(this.preparedList, Activity, salesDict, this);
            recyclerView.SetAdapter(catalogAdapter);
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);
            if (categories != null)
            {
                foreach (Category category in categories)
                {
                    menu.Add(0, category.Id, category.Id, category.Name);
                }
                menu.Add(0, -1, 0, "Todas categorias");
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(item.ItemId == -1)
            {
                _ = catalogViewModel.GetData();
            }else
            {
                _ = catalogViewModel.GetProductsByCategory(item.ItemId.ToString());
            }
            UpdateButtonBuyValue(0);
            return true;
        }

        public void LoadFiteredData(Android.Runtime.JavaList<object> preparedList)
        {
            this.preparedList.Clear();
            foreach(object o in preparedList)
            {
                this.preparedList.Add(o);
            }
            catalogAdapter.NotifyDataSetChanged();

        }
    }
}

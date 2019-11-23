
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using ShoppingApp.app.cart;
using static Android.Support.V7.Widget.RecyclerView;

namespace ShoppingApp.app.catalog
{
    public class CatalogFragment : Fragment 
    {

        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.fragment_catalog, container, false);
            setupRecyclerView(view);
            setupButtonBuy(view);
            return view;
                     
        }

        private void setupRecyclerView(View view)
        {

            RecyclerView recyclerView = view.FindViewById<RecyclerView>(Resource.Id.catalog_recyclerview);
            CatalogAdapter catalogAdapter = new CatalogAdapter();
            recyclerView.SetAdapter(catalogAdapter);

        }

        private void setupButtonBuy(View view)
        {
            Button buttonBuy = view.FindViewById<Button>(Resource.Id.button_buy);
            buttonBuy.Click += (sender, e) =>
            {
                Intent intent = new Intent(Activity, typeof(ShoppingCartActivity));
                Activity.StartActivity(intent);
            };
        }
    }
}


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
using static Android.Support.V7.Widget.RecyclerView;

namespace ShoppingApp.app.cart
{
    public class ShoppingCartFragment : Fragment 
    {

        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.fragment_shopping_cart, container, false);
            setupRecyclerView(view);
            return view;
                     
        }

        private void setupRecyclerView(View view)
        {

            RecyclerView recyclerView = view.FindViewById<RecyclerView>(Resource.Id.catalog_recyclerview);
            ShoppingCartAdapter shoppingCartAdapter = new ShoppingCartAdapter();
            recyclerView.SetAdapter(shoppingCartAdapter);

        }
    }
}

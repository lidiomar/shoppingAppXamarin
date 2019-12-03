using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Droid.app.catalog;
using Shared;
using ShoppingApp;
using ShoppingApp.app.model.catalog;

namespace Droid.app.cart
{
    public class ShoppingCartFragment : Fragment 
    {

        private TextView totalValueView;
        private TextView itemsCount;

        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.fragment_shopping_cart, container, false);

            this.totalValueView = view.FindViewById<TextView>(Resource.Id.total_value);
            this.itemsCount = view.FindViewById<TextView>(Resource.Id.items_count);

            SetupRecyclerView(view);
            return view;
                     
        }

        private void SetupRecyclerView(View view)
        {
            if (Activity.Intent.HasExtra(CatalogFragment.productJsonExtra) &&
                Activity.Intent.HasExtra(CatalogFragment.quantityJsonExtra) &&
                Activity.Intent.HasExtra(CatalogFragment.totalValueJsonExtra))
            {

                string jsonObject = Activity.Intent.GetStringExtra(CatalogFragment.productJsonExtra);
                List<Product> products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonObject);

                RecyclerView recyclerView = view.FindViewById<RecyclerView>(Resource.Id.cart_recyclerview);
                ShoppingCartAdapter shoppingCartAdapter = new ShoppingCartAdapter(products);
                recyclerView.SetAdapter(shoppingCartAdapter);

                this.totalValueView.Text = Utils.GetPrice(Activity.GetString(Resource.String.price), Activity.Intent.GetFloatExtra(CatalogFragment.totalValueJsonExtra, 0));
                int quantity = Activity.Intent.GetIntExtra(CatalogFragment.quantityJsonExtra, 0);
                this.itemsCount.Text = Utils.GetUN(Activity.GetString(Resource.String.un), quantity.ToString());
            }

        }
    }
}

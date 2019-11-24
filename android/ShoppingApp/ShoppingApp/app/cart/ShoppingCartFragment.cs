using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

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

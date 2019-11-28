using System;
using System.Collections.Generic;


using Android.Content;
using Android.OS;
using Android.Support.Constraints;
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
        public static readonly string productJsonExtra = "productsJson";
        public static readonly string quantityJsonExtra = "quantityJson";
        public static readonly string totalValueJsonExtra = "totalValueJson";

        protected CatalogViewModel catalogViewModel;
        private RecyclerView recyclerView;
        private ConstraintLayout main;
        private ProgressBar progressBar;
        private TextView message;
        private Button buttonBuy;
        private List<Category> categories;
        private CatalogAdapter catalogAdapter;
        private Android.Runtime.JavaList<Object> preparedList;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.fragment_catalog, container, false);

            progressBar = view.FindViewById<ProgressBar>(Resource.Id.progressbar);
            main = view.FindViewById<ConstraintLayout>(Resource.Id.main);
            message = view.FindViewById<TextView>(Resource.Id.message);
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.catalog_recyclerview);

            SetupButtonBuy(view);

            catalogViewModel = new CatalogViewModel(this);
            _ = catalogViewModel.GetData();
            HasOptionsMenu = true;

            return view;
                     
        }

        private void SetupButtonBuy(View view)
        {
            buttonBuy = view.FindViewById<Button>(Resource.Id.button_buy);
            buttonBuy.Click += (sender, e) =>
            {
                ICatalogAdapterViewModel catalogAdapterViewModel = catalogAdapter.catalogAdapterViewModel;

                List<Product> products = catalogAdapterViewModel.GetProductsToCart();
                string productsJson = Newtonsoft.Json.JsonConvert.SerializeObject(products);

                int quantity = catalogAdapterViewModel.GetQuantity();

                float totalValue = catalogAdapterViewModel.GetTotalValue();

                Intent intent = new Intent(Activity, typeof(ShoppingCartActivity));
                intent.PutExtra(productJsonExtra, productsJson);
                intent.PutExtra(quantityJsonExtra, quantity);
                intent.PutExtra(totalValueJsonExtra, totalValue);

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
            ShowMain();
            progressBar.Visibility = ViewStates.Gone;
            main.Visibility = ViewStates.Visible;
            message.Visibility = ViewStates.Gone;

            if (categories.Count > 0)
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
                menu.Add(0, -1, 0, Resource.String.all_categories);
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
            ShowMain();

            this.preparedList.Clear();
            foreach(object o in preparedList)
            {
                this.preparedList.Add(o);
            }
            catalogAdapter.NotifyDataSetChanged();

        }

        public void IsLoading(bool loading)
        {
            if (loading)
            {
                progressBar.Visibility = ViewStates.Visible;
                main.Visibility = ViewStates.Gone;
                message.Visibility = ViewStates.Gone;
            }
        }

        public void ShowErrorMessage()
        {
            progressBar.Visibility = ViewStates.Gone;
            main.Visibility = ViewStates.Gone;
            message.Visibility = ViewStates.Visible;
        }

        private void ShowMain()
        {
            progressBar.Visibility = ViewStates.Gone;
            main.Visibility = ViewStates.Visible;
            message.Visibility = ViewStates.Gone;
        }
    }
}

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Droid.app.catalog;
using ShoppingApp;

namespace Droid.app.cart
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ParentActivity = typeof(CatalogActivity), ScreenOrientation = ScreenOrientation.Portrait)]
    public class ShoppingCartActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_shopping_cart);
            SetupToolbar();
        }

        private void SetupToolbar()
        {
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.cart);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    
}
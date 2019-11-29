using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ShoppingApp;
using ShoppingApp.app.model.catalog;

namespace Droid.app.catalog
{
    public class CatalogSectionViewHolder : RecyclerView.ViewHolder
    {
        private TextView saleDescription;

        public CatalogSectionViewHolder(View view) : base(view)
        {
            this.saleDescription = view.FindViewById<TextView>(Resource.Id.sale_description);
        }

        public void Bind(Sale sale)
        {
            if(sale != null)
            {
                this.saleDescription.Text = sale.Name;
            }
            else
            {
                this.saleDescription.Text = "";
            }
            
        }
    }
}

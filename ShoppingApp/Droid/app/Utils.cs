using System;
using Android.Content;
using ShoppingApp;

namespace Droid.app
{
    public class Utils
    {
        public static string GetPrice(Context context, float priceValue)
        {
            string price = context.GetString(Resource.String.price);
            string priceFormated = String.Format(price, priceValue.ToString("0.00"));
            return priceFormated;
        }

        public static string GetUN(Context context, string quantity)
        {
            string un = context.GetString(Resource.String.un);
            string quantityFormated = String.Format(un, quantity);
            return quantityFormated;
        }

        public static string GetDiscount(Context context, string discount)
        {
            string discountString = context.GetString(Resource.String.discount);
            string discountFormated = String.Format(discountString, discount);
            return discountFormated;
        }
    }
}

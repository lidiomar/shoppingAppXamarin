using System;

namespace Shared
{
    public class Utils
    {
        public static string GetPrice(string price, float priceValue)
        {
            string priceFormated = String.Format(price, priceValue.ToString("0.00"));
            return priceFormated;
        }

        public static string GetUN(string un, string quantity)
        {
            string quantityFormated = String.Format(un, quantity);
            return quantityFormated;
        }

        public static string GetDiscount(string discountString, string discount)
        {
            string discountFormated = String.Format(discountString, discount);
            return discountFormated;
        }
    }
}

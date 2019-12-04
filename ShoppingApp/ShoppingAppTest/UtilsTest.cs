using NUnit.Framework;
using Shared;

namespace ShoppingAppTest
{
    [TestFixture()]
    public class UtilsTest
    {
        [Test()]
        public void PriceFormatTest()
        {
            string expectedString = "R$ 10.00";
            string priceString = "R$ {0}";
            string formatted = Utils.GetPrice(priceString, 10f);

            Assert.AreEqual(formatted, expectedString);
        }

        [Test()]
        public void UNFormatTest()
        {
            string expectedString = "10 UN";
            string unString = "{0} UN";
            int un = 10;
            string formatted = Utils.GetUN(unString, un.ToString());

            Assert.AreEqual(formatted, expectedString);
        }

        [Test()]
        public void DiscountFormatTest()
        {
            string expectedString = "10%";
            string discountString = "{0}%";
            int discount = 10;
            string formatted = Utils.GetDiscount(discountString, discount.ToString());

            Assert.AreEqual(formatted, expectedString);
        }
    }
}

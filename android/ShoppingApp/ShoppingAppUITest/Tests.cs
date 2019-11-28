using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ShoppingAppUITest
{
    [TestFixture]
    public class Tests
    {
        IApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp.Android.ApkFile("../../../ShoppingApp/bin/Debug/br.com.lidiocorp.shoppingapp.apk").StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            Assert.NotNull(app.Query(c => c.Marked("button_buy")));
            app.Screenshot("catalog screen");
        }

        [Test]
        public void CartScreen()
        {
            app.Tap(c => c.Marked("button_plus"));
            app.Tap(c => c.Marked("button_buy"));
            Assert.NotNull(app.Query(c => c.Marked("cart_recyclerview")));
            app.Screenshot("cart screen");
        }
    }
}

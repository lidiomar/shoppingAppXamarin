using NUnit.Framework;
using Shared.viewmodel;
using System;
namespace ShoppingAppTest
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            Bla bla = new Bla();
            Assert.AreEqual(4, bla.DoubleMe(2));
        }
    }
}

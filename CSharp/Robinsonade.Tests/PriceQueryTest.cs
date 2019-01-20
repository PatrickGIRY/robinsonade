using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Robinsonade.Tests
{
    [TestClass]
    public class PriceQueryTest
    {
        private PriceQuery priceQuery;

        [TestInitialize]
        public void Initialize()
        {
            priceQuery = new PriceQuery();
        }

        [TestMethod]
        public void find_the_price_given_an_item_code()
        {
            Check.That(priceQuery.FindPrice("APPLE")).IsEqualTo(Price.ValueOf(1.20));
        }
    }
}

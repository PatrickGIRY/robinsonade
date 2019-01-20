using System;
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
            priceQuery = new PriceQuery(
                ItemReference.aReference().withItemCode("APPLE").withUnitPrice(1.20).build(),
                ItemReference.aReference().withItemCode("BANANA").withUnitPrice(1.90).build());
        }

        [DataTestMethod]
        [DataRow("APPLE", 1.20)]
        [DataRow("BANANA", 1.90)]
        public void find_the_price_given_an_item_code(String itemCode, double unitPrice)
        {
            Check.That(priceQuery.FindPrice(itemCode)).IsEqualTo(Price.ValueOf(unitPrice));
        }

        [TestMethod]
        public void search_an_unknow_item()
        {
            Check.That(priceQuery.FindPrice("PEACH")).IsNull();
        }
    }
}

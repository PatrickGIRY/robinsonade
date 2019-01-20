using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Robinsonade.Tests
{
    [TestClass]
    public class CashRegisterTest
    {
        private CashRegister cashRegister;
        private PriceQuery priceQuery;

        [TestInitialize]
        public void Initialize()
        {
            cashRegister = new CashRegister();
            priceQuery = new PriceQuery(
                ItemReference.aReference().withItemCode("APPLE").withUnitPrice(1.20).build(),
                ItemReference.aReference().withItemCode("BANANA").withUnitPrice(1.90).build());
        }

        [DataTestMethod]
        [DataRow("APPLE", 1, 1.20)]
        [DataRow("APPLE", 2, 1.20)]
        [DataRow("BANANA", 1, 1.90)]
        public void total_is_product_of_quantity_by_item_price_corresponding_to_existing_item_code(
            String itemCode,
            double quantity, 
            double unitPrice)
        {
            Result total = cashRegister.Total(priceQuery.FindPrice(itemCode), Quantity.ValueOf(quantity));
            Check.That(total).IsEqualTo(Result.Found(Price.ValueOf(quantity * unitPrice)));
        }

        [TestMethod]
        public void total_not_found_when_item_price_not_found()
        {
            Result total = cashRegister.Total(priceQuery.FindPrice("PEACH"), Quantity.ValueOf(1));
            Check.That(total).IsEqualTo(Result.NotFound("PEACH"));
        }
    }
}

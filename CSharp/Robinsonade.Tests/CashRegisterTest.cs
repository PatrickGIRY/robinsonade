using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Robinsonade.Tests
{
    [TestClass]
    public class CashRegisterTest
    {
        private CashRegister cashRegister;

        [TestInitialize]
        public void Initialize()
        {
            cashRegister = new CashRegister();
        }

        [TestMethod]
        public void total_is_product_of_quantity_by_item_price()
        {
            double price = 1.20;
            double quantity = 1;
            double total = cashRegister.Total(price, quantity);
            Check.That(total).IsEqualTo(1.20);
        }
    }
}

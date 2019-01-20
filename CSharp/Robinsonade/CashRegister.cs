namespace Robinsonade
{
    public class CashRegister
    {
        public Price Total(Price price, double quantity)
        {
            return price.MultiplyBy(quantity);
        }
    }
}

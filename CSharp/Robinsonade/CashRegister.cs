namespace Robinsonade
{
    public class CashRegister
    {
        public Price Total(Price price, Quantity quantity)
        {
            return price.MultiplyBy(quantity);
        }
    }
}

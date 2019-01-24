namespace Robinsonade
{
    public class CashRegister
    {
        public Result Total(Result result, Quantity quantity)
        {
            return result.Map(price => price.MultiplyBy(quantity));
        }
    }
}

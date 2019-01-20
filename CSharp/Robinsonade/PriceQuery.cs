using System;

namespace Robinsonade
{
    public class PriceQuery
    {
        public Price FindPrice(String itemCode)
        {
            return Price.ValueOf(1.20);
        }
    }
}

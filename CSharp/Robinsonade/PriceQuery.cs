using System;
using System.Collections.Generic;

namespace Robinsonade
{
    public class PriceQuery
    {
        private readonly ItemReference[] itemReferences;

        public PriceQuery(params ItemReference[] itemReferences)
        {
            this.itemReferences = itemReferences;
        }

        public Result FindPrice(String soughtItemCode)
        {
            return Reduce(Result.NotFound(soughtItemCode),
                (result, itemReference) =>
                {
                    if (itemReference.matchSoughtItemCode(soughtItemCode))
                    {
                        return Result.Found(itemReference.getUnitPrice());
                    }
                    return result;
                },
                itemReferences);
        }

        static R Reduce<T, R>(R identity, Func<R, T, R> reducer, IEnumerable<T> values)
        {
            R result = identity;
            foreach (var value in values)
            {
                result = reducer(result, value);
            }
            return result;
        }
    }
}

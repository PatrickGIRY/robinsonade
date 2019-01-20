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
                (result, itemReference)=>Result.Found(itemReference.GetUnitPrice()),
                Filter(itemReference=>itemReference.matchSoughtItemCode(soughtItemCode),
                    itemReferences));
        }

        private static List<T> Filter<T>(Func<T, bool> predicate, IEnumerable<T> values)
        {
            return Reduce(new List<T>(),
                (accumulator, value) => predicate(value)
                    ? Append(accumulator, value)
                    : accumulator, values);
        }

        private static T Append<T, TR>(T accumulator, TR value) where T : List<TR>
        {
            accumulator.Add(value);
            return accumulator;
        }

        static TR Reduce<T, TR>(TR identity, Func<TR, T, TR> reducer, IEnumerable<T> values)
        {
            var result = identity;
            foreach (var value in values)
            {
                result = reducer(result, value);
            }
            return result;
        }
    }
}

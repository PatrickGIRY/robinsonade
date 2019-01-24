using System;
using System.Collections.Generic;
using System.Linq;

namespace Robinsonade
{
    public class PriceQuery
    {
        private readonly Dictionary<String, Price> itemReferences;

        public PriceQuery(params ItemReference[] itemReferences)
        {
            this.itemReferences = itemReferences.ToDictionary(i=> i.ItemCode, i=> i.GetUnitPrice());
        }

        public Result FindPrice(String soughtItemCode)
        {
            var item = itemReferences.GetValueOrDefault(soughtItemCode);
            var result = item == null
                ? Result.NotFound(soughtItemCode)
                : Result.Found(item);

            return result;
        }
    }
}

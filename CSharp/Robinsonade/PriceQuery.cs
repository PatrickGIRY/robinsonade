using System;
using System.Linq;

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
            var enumerable = itemReferences.Where(r => r.matchSoughtItemCode(soughtItemCode));
            Result result = enumerable.Any()
                ? Result.Found(enumerable.Select(i => i.GetUnitPrice()).First())
                : Result.NotFound(soughtItemCode);

            return result;
        }
    }
}

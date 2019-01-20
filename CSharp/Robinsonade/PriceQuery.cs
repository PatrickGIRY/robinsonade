using System;

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
            foreach (var itemReference in itemReferences)
            {
                if (itemReference.matchSoughtItemCode(soughtItemCode))
                {
                    return Result.Found(itemReference.getUnitPrice());
                }
            }

            return Result.NotFound(soughtItemCode);
        }
    }
}

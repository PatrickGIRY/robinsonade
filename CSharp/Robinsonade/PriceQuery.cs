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

        public Price FindPrice(String soughtItemCode)
        {
            foreach (var itemReference in itemReferences)
            {
                if (itemReference.matchSoughtItemCode(soughtItemCode))
                {
                    return itemReference.getUnitPrice();
                }
            }
            
            return null;
        }
    }
}

using System;

namespace Robinsonade
{
    public class ItemReference
    {
        private readonly String itemCode;
        private readonly Price unitPrice;

        public static Builder aReference()
        {
            return new Builder();
        }

        private ItemReference(String itemCode, Price unitPrice)
        {
            this.itemCode = itemCode;
            this.unitPrice = unitPrice;
        }

        public bool matchSoughtItemCode(String soughtItemCode)
        {
            return itemCode.Equals(soughtItemCode);
        }

        public Price getUnitPrice()
        {
            return unitPrice;
        }

        public class Builder
        {
            private String itemCode;
            private Price unitPrice;

            internal Builder()
            {
            }

            public Builder withItemCode(String itemCode)
            {
                this.itemCode = itemCode;
                return this;
            }

            public Builder withUnitPrice(double unitPrice)
            {
                return withUnitPrice(Price.ValueOf(unitPrice));
            }

            public Builder withUnitPrice(Price unitPrice)
            {
                this.unitPrice = unitPrice;
                return this;
            }

            public ItemReference build()
            {
                return new ItemReference(itemCode, unitPrice);
            }
        }
    }
}

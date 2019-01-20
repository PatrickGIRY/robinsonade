using System;

namespace Robinsonade
{
    public class ItemReference
    {
        private readonly String itemCode;
        private readonly Price unitPrice;

        public string ItemCode => itemCode;

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

        public Price GetUnitPrice()
        {
            return unitPrice;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            ItemReference that = (ItemReference)obj;
            return itemCode.Equals(that.itemCode) &&
                   unitPrice.Equals(that.unitPrice);
        }

        public override string ToString()
        {
            return "ItemReference{" +
                   "itemCode='" + itemCode + '\'' +
                   ", unitPrice=" + unitPrice +
                   '}';
        }

        public override int GetHashCode()
        {
            return itemCode.GetHashCode()
                   + unitPrice.GetHashCode();
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

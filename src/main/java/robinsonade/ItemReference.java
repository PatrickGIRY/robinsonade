package robinsonade;

import java.util.Objects;

class ItemReference {
    private final String itemCode;
    private final Price unitPrice;

    static Builder aReference() {
        return new Builder();
    }

    private ItemReference(String itemCode, Price unitPrice) {
        this.itemCode = itemCode;
        this.unitPrice = unitPrice;
    }

    boolean matchSoughtItemCode(String soughtItemCode) {
        return Objects.equals(itemCode, soughtItemCode);
    }

    String getItemCode() { return itemCode; }

    Price getUnitPrice() { return unitPrice; }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ItemReference that = (ItemReference) o;
        return Objects.equals(itemCode, that.itemCode) &&
                Objects.equals(unitPrice, that.unitPrice);
    }

    @Override
    public int hashCode() {
        return Objects.hash(itemCode, unitPrice);
    }

    @Override
    public String toString() {
        return "ItemReference{" +
                "itemCode='" + itemCode + '\'' +
                ", unitPrice=" + unitPrice +
                '}';
    }

    static final class Builder {
        private String itemCode;
        private Price unitPrice;

        private Builder() {}

        Builder withItemCode(String itemCode) {
            this.itemCode = itemCode;
            return this;
        }

        Builder withUnitPrice(double unitPrice) {
            return withUnitPrice(Price.valueOf(unitPrice));
        }

        Builder withUnitPrice(Price unitPrice) {
            this.unitPrice = unitPrice;
            return this;
        }

        ItemReference build() {
            return new ItemReference(itemCode, unitPrice);
        }
    }
}

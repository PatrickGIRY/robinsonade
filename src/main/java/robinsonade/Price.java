package robinsonade;

import java.util.Objects;

class Price {
    private final double value;

    static Price valueOf(double value) { return new Price(value); }

    private Price(double value) { this.value = value; }

    Price multiplyBy(double quantity) { return valueOf(value * quantity); }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Price price = (Price) o;
        return Double.compare(price.value, value) == 0;
    }

    @Override
    public int hashCode() {
        return Objects.hash(value);
    }

    @Override
    public String toString() {
        return "Price{ value=" + value + '}';
    }
}

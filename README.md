# Robinsonade

## Calcul du total

Le total est le produit d'un prix d'un article par une quantité.

    total = price x quantity

Signature de la fonction total

    total : double x double -> double

    double price = 1.20;
    double quantity = 1;
    double total = cashRegister.total(price, quantity);

    assertThat(total).isEqualTo(1.20);

    double total(double price, double quantity) {
        return  price * quantity;
    }

## Ajouter un ValueType poue le prix

    Price price = Price.valueOf(1.20);
    double quantity = 1;
    Price total = cashRegister.total(price, quantity);

    assertThat(total).isEqualTo(Price.valueOf(1.20));

    Price total(Price price, double quantity) {
        return  price.multiplyBy(quantity);
    }

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


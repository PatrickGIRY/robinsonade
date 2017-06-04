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

## Ajouter un ValueType pour la quantité

    Price price = Price.valueOf(1.20);
    Quantity quantity = Quantity.valueOf(1);
    Price total = cashRegister.total(price, quantity);

    assertThat(total).isEqualTo(Price.valueOf(1.20));

    Price total(Price price, Quantity quantity) {
        return  price.multiplyBy(quantity);
    }

    class Price {
        private final double value;

        static Price valueOf(double value) { return new Price(value); }

        private Price(double value) { this.value = value; }

        Price multiplyBy(Quantity quantity) { return valueOf(quantity.multiplyBy(value)); }

        ...
    }

    class Quantity {

        private final double value;

        static Quantity valueOf(double value) { return new Quantity(value); }

        private Quantity(double value) { this.value = value; }

        double multiplyBy(double value) { return this.value * value; }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Quantity quantity = (Quantity) o;
            return Double.compare(quantity.value, value) == 0;
        }

        @Override
        public int hashCode() {
            return Objects.hash(value);
        }

        @Override
        public String toString() {
            return "Quantity{" + "value=" + value + '}';
        }
    }

## Ajouter la fonctionnalité pour rechercher le prix d'un article en fonction de son code

    @Test
    public void find_the_price_given_an_item_code() {
        assertThat(priceQuery.findPrice("APPLE")).isEqualTo(Price.valueOf(1.20));
    }   

    class PriceQuery {

       Price findPrice(String itemCode) {
            return Price.valueOf(1.20);
       }
    } 

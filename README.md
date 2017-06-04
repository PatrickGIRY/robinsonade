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

## Tester la recherche du prix de plusieurs articles

    @Parameters({"APPLE, 1.20",
                "BANANA, 1.90"})
    @Test
    public void find_the_price_given_an_item_code(String itemCode, double unitPrice) {
        assertThat(priceQuery.findPrice(itemCode)).isEqualTo(Price.valueOf(unitPrice));
    }

    priceQuery = new PriceQuery(
                aReference().withItemCode("APPLE").withUnitPrice(1.20).build(),
                aReference().withItemCode("BANANA").withUnitPrice(1.90).build());

    class ItemReference {
        private final String itemCode;
        private final Price unitPrice;

        static Builder aReference() { return new Builder(); }

        private ItemReference(String itemCode, Price unitPrice) {
            this.itemCode = itemCode;
            this.unitPrice = unitPrice;
        }

        boolean matchSoughtItemCode(String soughtItemCode) {
            return Objects.equals(itemCode, soughtItemCode);
        }

        Price getUnitPrice() { return unitPrice; }

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

## Tester la recherche d'un prix d'un article qui n'existe pas

    assertThat(priceQuery.findPrice("PEACH")).isNull();

## Ajouter un type `Result` pour indiquer le prix de l'article est trouvé ou pas

    assertThat(priceQuery.findPrice(itemCode)).isEqualTo(Result.found(Price.valueOf(unitPrice)));

    assertThat(priceQuery.findPrice("PEACH")).isEqualTo(Result.notFound("PEACH"));

    abstract class Result {
        static Result found(Price price) { return new Found(price); }

        static Result notFound(String invalidItemCode) { return new NotFound(invalidItemCode); }

        private static class Found extends Result {
            private final Price price;

            private Found(Price price) {
                super();
                this.price = price;
            }

            @Override
            public boolean equals(Object o) {
                if (this == o) return true;
                if (o == null || getClass() != o.getClass()) return false;
                Found found = (Found) o;
                return Objects.equals(price, found.price);
            }

            @Override
            public int hashCode() {
                return Objects.hash(price);
            }

            @Override
            public String toString() {
                return "Found{" +
                        "price=" + price +
                        "} " + super.toString();
            }
        }

        private static class NotFound extends Result {
            private final String invalidItemCode;

            private NotFound(String invalidItemCode) {
                super();
                this.invalidItemCode = invalidItemCode;
            }

            @Override
            public boolean equals(Object o) {
                if (this == o) return true;
                if (o == null || getClass() != o.getClass()) return false;
                NotFound notFound = (NotFound) o;
                return Objects.equals(invalidItemCode, notFound.invalidItemCode);
            }

            @Override
            public int hashCode() {
                return Objects.hash(invalidItemCode);
            }

            @Override
            public String toString() {
                return "NotFound{" +
                        "invalidItemCode='" + invalidItemCode + '\'' +
                        "} " + super.toString();
            }
        }
    }

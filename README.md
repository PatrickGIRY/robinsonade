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


package robinsonade;

class CashRegister {
    Price total(Price price, double quantity) {
        return  price.multiplyBy(quantity);
    }
}

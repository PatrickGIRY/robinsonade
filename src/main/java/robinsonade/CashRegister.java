package robinsonade;

class CashRegister {
    Result total(Result result, Quantity quantity) {
        return  result.map(price -> price.multiplyBy(quantity));
    }
}

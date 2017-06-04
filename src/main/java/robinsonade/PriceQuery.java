package robinsonade;

class PriceQuery {

    private final ItemReference[] itemReferences;

    public PriceQuery(ItemReference... itemReferences) {
        this.itemReferences = itemReferences;
    }

    Price findPrice(String soughtItemCode) {
        for (ItemReference itemReference : itemReferences) {
            if (itemReference.matchSoughtItemCode(soughtItemCode)) {
                return itemReference.getUnitPrice();
            }
        }

        return null;
    }
}

package robinsonade;

class PriceQuery {

    private final ItemReference[] itemReferences;

    public PriceQuery(ItemReference... itemReferences) {
        this.itemReferences = itemReferences;
    }

    Result findPrice(String soughtItemCode) {
        for (ItemReference itemReference : itemReferences) {
            if (itemReference.matchSoughtItemCode(soughtItemCode)) {
                return Result.found(itemReference.getUnitPrice());
            }
        }
        return Result.notFound(soughtItemCode);
    }
}

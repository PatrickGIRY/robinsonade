package robinsonade;

import java.util.stream.Stream;

class PriceQuery {

    private final ItemReference[] itemReferences;

    public PriceQuery(ItemReference... itemReferences) {
        this.itemReferences = itemReferences;
    }

    Result findPrice(String soughtItemCode) {

        return Stream.of(itemReferences)
                .filter(r -> r.matchSoughtItemCode(soughtItemCode))
                .map(ItemReference::getUnitPrice)
                .map(Result::found)
                .findFirst()
                .orElseGet(() -> Result.notFound(soughtItemCode));
    }

}

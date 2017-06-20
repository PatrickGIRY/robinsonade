package robinsonade;

import java.util.Map;
import java.util.stream.Stream;

import static java.util.stream.Collectors.toMap;

class PriceQuery {

    private final Map<String, Price> itemReferencesByItemCode;

    public PriceQuery(ItemReference... itemReferences) {
        this.itemReferencesByItemCode = Stream.of(itemReferences).collect(toMap(ItemReference::getItemCode, ItemReference::getUnitPrice));
    }

    Result findPrice(String soughtItemCode) {
        Price price = itemReferencesByItemCode.get(soughtItemCode);
        return price != null ? Result.found(price) : Result.notFound(soughtItemCode);
    }
}

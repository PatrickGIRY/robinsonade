package robinsonade;

import java.util.Arrays;
import java.util.function.BiFunction;

class PriceQuery {

    private final ItemReference[] itemReferences;

    public PriceQuery(ItemReference... itemReferences) {
        this.itemReferences = itemReferences;
    }

    Result findPrice(String soughtItemCode) {
        return reduce(Result.notFound(soughtItemCode),
                (result, itemReference) -> {
            if (itemReference.matchSoughtItemCode(soughtItemCode)) {
                return Result.found(itemReference.getUnitPrice());
            } else {
                return result;
            }
        }, Arrays.asList(itemReferences));
    }

    static <T, R> R reduce(R identity, BiFunction<R, T, R> reducer, Iterable<T> values) {
        R result = identity;
        for (T value : values) {
            result = reducer.apply(result, value);
        }
        return result;
    }
}

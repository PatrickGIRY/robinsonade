package robinsonade;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.BiFunction;
import java.util.function.Predicate;

class PriceQuery {

    private final ItemReference[] itemReferences;

    public PriceQuery(ItemReference... itemReferences) {
        this.itemReferences = itemReferences;
    }

    Result findPrice(String soughtItemCode) {
        return reduce(Result.notFound(soughtItemCode),
                (result, itemReference) -> Result.found(itemReference.getUnitPrice()),
                filter(itemReference -> itemReference.matchSoughtItemCode(soughtItemCode), Arrays.asList(itemReferences)));
    }

    private static <T> List<T> filter(Predicate<T> predicate, Iterable<T> values) {
        return reduce(new ArrayList<>(), (accumulator, value) -> predicate.test(value) ? append(accumulator, value) : accumulator,  values);
    }
    

    private static <T extends List<R>, R> T append(T accumulator, R value) {
        accumulator.add(value);
        return accumulator;
    }


    private static <T, R> R reduce(R identity, BiFunction<R, T, R> reducer, Iterable<T> values) {
        R result = identity;
        for (T value : values) {
            result = reducer.apply(result, value);
        }
        return result;
    }
}

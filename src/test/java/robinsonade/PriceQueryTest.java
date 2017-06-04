package robinsonade;


import junitparams.JUnitParamsRunner;
import junitparams.Parameters;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;

import static org.assertj.core.api.Assertions.assertThat;
import static robinsonade.ItemReference.aReference;

@RunWith(JUnitParamsRunner.class)
public class PriceQueryTest {

    private PriceQuery priceQuery;

    @Before
    public void setUp() throws Exception {
        priceQuery = new PriceQuery(
                aReference().withItemCode("APPLE").withUnitPrice(1.20).build(),
                aReference().withItemCode("BANANA").withUnitPrice(1.90).build());
    }

    @Parameters({"APPLE, 1.20",
                "BANANA, 1.90"})
    @Test
    public void find_the_price_given_an_item_code(String itemCode, double unitPrice) {
        assertThat(priceQuery.findPrice(itemCode)).isEqualTo(Result.found(Price.valueOf(unitPrice)));
    }

    @Test
    public void search_an_unknow_item() {
        assertThat(priceQuery.findPrice("PEACH")).isEqualTo(Result.notFound("PEACH"));
    }
}

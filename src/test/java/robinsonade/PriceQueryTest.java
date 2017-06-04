package robinsonade;


import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class PriceQueryTest {

    private PriceQuery priceQuery;

    @Before
    public void setUp() throws Exception {
        priceQuery = new PriceQuery();
    }

    @Test
    public void find_the_price_given_an_item_code() {
        assertThat(priceQuery.findPrice("APPLE")).isEqualTo(Price.valueOf(1.20));
    }
}

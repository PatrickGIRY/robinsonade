package robinsonade;

import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;


public class CashRegisterTest {

    private CashRegister cashRegister;

    @Before
    public void setUp() throws Exception {
        cashRegister = new CashRegister();
    }

    @Test
    public void total_is_product_of_quantity_by_item_price() {

        Price price = Price.valueOf(1.20);
        Quantity quantity = Quantity.valueOf(1);
        Price total = cashRegister.total(price, quantity);

        assertThat(total).isEqualTo(Price.valueOf(1.20));
    }
}

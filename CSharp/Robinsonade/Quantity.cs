namespace Robinsonade
{
    public class Quantity
    {
        private readonly double value;

        public static Quantity ValueOf(double value) { return new Quantity(value); }

        private Quantity(double value) { this.value = value; }

        public double MultiplyBy(double value) { return this.value * value; }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;
            Quantity quantity = obj as Quantity;
            return quantity.value.Equals(value);
        }

        public override string ToString()
        {
            return "Quantity{" + "value=" + value + '}';
        }
    }
}
